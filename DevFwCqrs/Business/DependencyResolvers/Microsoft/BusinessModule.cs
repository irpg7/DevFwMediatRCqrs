using MediatR;
using Core.Utilities.IoC;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


namespace Business.DependencyResolvers.Microsoft
{
    public class BusinessModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddTransient<IProductDal, EfProductDal>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
