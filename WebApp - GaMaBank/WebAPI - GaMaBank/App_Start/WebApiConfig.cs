﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI___GaMaBank
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //CORS configuration
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors); 

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
