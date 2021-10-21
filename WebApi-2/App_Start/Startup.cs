using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Data;
using Microsoft.Owin;
using Owin;
using Repository.UnitOfWorkRepositories;
using System;
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

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
