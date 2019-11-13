using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiBackendTeste.Formatter;
using WebApiBackendTeste.Model;

namespace WebApiBackendTeste
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );
            config.Formatters.Add(new HalJsonMediaTypeFormatter());

            /*   var json = config.Formatters.JsonFormatter;
                  json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                  config.Formatters.Remove(config.Formatters.XmlFormatter);
                  json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;*/


        }

    }
}
