using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.DependencyResolvers.Microsoft;
using Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.Encryption;

namespace CoreRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDependencyResolvers(new Core.Utilities.IoC.ICoreModule[]
            {
                new BusinessModule()
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey)
                    };
                }
                );
            services.AddAuthorization();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(options =>
            {
                options.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                .SetIsOriginAllowed(isOriginAllowed: _ => true);
            });
            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
