using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TMS_Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // enable cors

            registerCorsClientHTTP(config);

            /*var cors = new EnableCorsAttribute("https://localhost:44385", "*", "*");
            config.EnableCors(cors);
            config.EnableCors()*/
        }

        private static void registerCorsClientHTTP(HttpConfiguration config)
        {
            List<EnableCorsAttribute> corsList = new List<EnableCorsAttribute>()
            {
                new EnableCorsAttribute("*","*","*") // allow origins request
                /*new EnableCorsAttribute("https://localhost:44385","*","*"),
                new EnableCorsAttribute("https://localhost:44352","*","*"),*/
            };
            corsList.ForEach((currentCors) =>
            {
                config.EnableCors(currentCors);
            });


        }
    }
}
