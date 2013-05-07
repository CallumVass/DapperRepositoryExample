using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Mvc;
using ServiceStack.Configuration;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;
using Ninject;
using ServiceInterface;
using DomainModel.Contracts;
using DataAccess;

[assembly: WebActivator.PreApplicationStartMethod(typeof(WebUI.App_Start.AppHost), "Start")]

//IMPORTANT: Add the line below to MvcApplication.RegisterRoutes(RouteCollection) in the Global.asax:
//routes.IgnoreRoute("api/{*pathInfo}"); 

/**
 * Entire ServiceStack Starter Template configured with a 'Hello' Web Service and a 'Todo' Rest Service.
 *
 * Auto-Generated Metadata API page at: /metadata
 * See other complete web service examples at: https://github.com/ServiceStack/ServiceStack.Examples
 */

namespace WebUI.App_Start
{
    public class AppHost
        : AppHostBase
    {
        public AppHost() //Tell ServiceStack the name and where to find your web services
            : base("Dapper Example", typeof(UsersService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            //Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
            
            //Tell SS to use Ninject rather then Funq
            IKernel kernel = new StandardKernel();
            container.Adapter = new NinjectIocAdapter(kernel);

            //Custom Method to register dependencies, can be wherever you want (even inside this method), I just put it in this class
            RegisterDependencies(kernel);

            //Set MVC to use the same Funq IOC as ServiceStack
            //ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            //Now tell MVC to use Ninject for controller DI, rather than Funq (See above if you want to use Funq)
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
        }

        public void RegisterDependencies(IKernel kernel)
        {
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
        }

        public static void Start()
        {
            new AppHost().Init();
        }
    }
}