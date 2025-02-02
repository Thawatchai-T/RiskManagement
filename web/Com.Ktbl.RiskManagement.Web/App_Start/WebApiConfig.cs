﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Com.Ktbl.RiskManagement.Web
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }


        public static void Register(HttpConfiguration config)
        {
            /** [20141118] woody add config for custom function in webapi */
            config.Routes.MapHttpRoute(
                name: "ApiById",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^[0-9]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByName",
                routeTemplate: "api/{controller}/{action}/{name}",
                defaults: null,
                constraints: new { name = @"^[a-z]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Get" }
            );

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

        }
    }

    /*
     * code old
     */
    //public static class WebApiConfig
    //{
    //    public static void Register(HttpConfiguration config)
    //    {
    //        config.Routes.MapHttpRoute(
    //            name: "ApiByName",
    //            routeTemplate: "api/{controller}/{action}/{name}",
    //            defaults: null,
    //            constraints: new { name = @"^[a-z]+$" }
    //        );
    //        
    //        config.Routes.MapHttpRoute(
    //            name: "DefaultApi",
    //            routeTemplate: "api/{controller}/{id}",
    //            defaults: new { id = RouteParameter.Optional }
    //        );
    //    }
    //}
}
