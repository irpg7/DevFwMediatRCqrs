using MediatR;
using Core.Utilities.IoC;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.NpgSql;
using Core.Utilities.Security.Jwt;
using AutoMapper;

namespace Business.DependencyResolvers.Microsoft
{
    public class BusinessModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IProductDal, PgProductDal>();
            services.AddScoped<IUserDal, PgUserDal>();
            services.AddScoped<IUserOperationClaimDal, PgUserOperationClaimDal>();
            services.AddScoped<IOperationClaimDal, PgOperationClaimDal>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
