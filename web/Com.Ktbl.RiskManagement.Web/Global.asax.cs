using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Com.Ktbl.RiskManagement.Process;
using Spring.Web.Mvc;

namespace Com.Ktbl.RiskManagement.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            JobScheduler.Start();
        }

        protected override System.Web.Http.Dependencies.IDependencyResolver BuildWebApiDependencyResolver()
        {
            //get the 'default' resolver, populated from the 'main' config metadata
            var resolver = base.BuildWebApiDependencyResolver();

            //check if its castable to a SpringWebApiDependencyResolver
            var springResolver = resolver as SpringWebApiDependencyResolver;

            //if it is, add additional config sources as needed
            if (springResolver != null)
            {
                //springResolver.AddChildApplicationContextConfigurationLocation("file://~/Config/child_controllers.xml");
            }
         
            //return the fully-configured resolver
            return resolver;
        }
    }
}