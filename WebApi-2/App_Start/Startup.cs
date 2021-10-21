using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Data;
using Data.Configurations.AutoMapper;
using Microsoft.Owin;
using Owin;
using Repository.UnitOfWorkRepositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(WebApi_2.App_Start.Startup))]

namespace WebApi_2.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // Register cac controller dang duoc khoi tao
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register web api controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWorkRepository>().As<IUnitOfWorkRepository>().InstancePerRequest();
            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest();



            builder.RegisterType<MapperInitializer>().As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
