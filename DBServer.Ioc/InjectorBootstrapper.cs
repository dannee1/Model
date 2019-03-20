using AutoMapper;
using DbServer.Data.Context;
using DbServer.Data.Repository;
using DbServer.Domain.Interfaces;
using DbServer.Service;
using DbServer.Service.Interface;
using DBServer.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DBServer.Ioc
{
    public static class InjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Context EF Core
            services.AddDbContext<SqlContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DbContext"));
            });

            ////Data
            services.AddScoped<ICheckingAccountRepository, CheckingAccountRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            ////Service
            services.AddScoped<ICheckingAccountService, CheckingAccountService>();
            services.AddScoped<IPostService, PostService>();

            //Automapper.
            MapperConfiguration mapperConfiguration = new MapperConfiguration(mConfig =>
            {
                mConfig.AddProfile(new MapProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
