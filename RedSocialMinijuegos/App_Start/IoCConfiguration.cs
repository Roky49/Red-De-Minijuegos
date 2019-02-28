using Autofac;
using Autofac.Integration.Mvc;
using RedSocialMinijuegos.Models;
using RedSocialMinijuegos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace RedSocialMinijuegos.App_Start
{
    public class IoCConfiguration
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            RegistrarControladores(builder);
            RegistrarObjetos(builder);
            RegistrarRepositorios(builder);

            IContainer contenedor = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(contenedor));
        }

        public static void RegistrarObjetos(ContainerBuilder builder)
        {
            builder.Register(z => new MinijuegosContexto()).InstancePerRequest();
        }

        public static void RegistrarRepositorios(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryMinijuegos>().As<IRepositoryMinijuegos>().InstancePerRequest();
        }

        private static void RegistrarControladores(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }



    }
}