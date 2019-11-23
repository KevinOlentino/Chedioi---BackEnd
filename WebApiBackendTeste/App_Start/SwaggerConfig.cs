using System.Web.Http;
using WebActivatorEx;
using WebApiBackendTeste;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiBackendTeste
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {

                        c.SingleApiVersion("v1", "WebApiBackendTeste");
                                              
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        
                    })
                .EnableSwaggerUi(c =>
                    {                       
                        c.DocumentTitle("My Swagger UI");
                        c.EnableDiscoveryUrlSelector();
                    });
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\WebApiBackendTeste.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
