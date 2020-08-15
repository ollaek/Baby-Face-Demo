using BabyFace.Api.Handlers;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Web.Http;
//using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace BabyFace.Api
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      // Configure Web API to use only bearer token authentication.
      config.SuppressDefaultHostAuthentication();
      config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
      config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
      config.MessageHandlers.Add(new ResponseHandler());
            //var corsAttr = new EnableCorsAttribute("*", "*", "*");
            //corsAttr.SupportsCredentials = true;
            //config.EnableCors(corsAttr);
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            // JSON formatter
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //to convert date time to local
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
