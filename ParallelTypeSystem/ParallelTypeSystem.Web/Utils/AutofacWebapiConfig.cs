using Autofac;
using Autofac.Integration.WebApi;
using ParallelTypeSystem.Data;
using ParallelTypeSystem.Interfaces;
using ParallelTypeSystem.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ParallelTypeSystem.Web.Utils
{
    public class AutofacWebapiConfig
    {
        public static IContainer container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ParallelTypeSystemEntities>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                   .As<IDbFactory>()
                   .InstancePerRequest();

            RegisterRepositories(builder);

            //Set the dependency resolver to be Autofac.  
            container = builder.Build();

            return container;
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            Assembly servicesAssembly = Assembly.GetAssembly(typeof(UserService));
            Assembly interfacesAssembly = Assembly.GetAssembly(typeof(IUserService));
            Assembly[] arr = { servicesAssembly, interfacesAssembly };
            builder.RegisterAssemblyTypes(arr)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}