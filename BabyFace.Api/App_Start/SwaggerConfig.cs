using BabyFace.Api;
using Swashbuckle.Application;
using System.Linq;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BabyFace.Api
{
  public class SwaggerConfig
  {
    public static void Register()
    {
      var thisAssembly = typeof(SwaggerConfig).Assembly;

      //GlobalConfiguration.Configuration
      //    .EnableSwagger(c =>
      //        {              
      //          c.SingleApiVersion("v1", "BabyFace.Api");
      //          c.ApiKey("Token")
      //      .Description("Filling bearer token here")
      //      .Name("Authorization")
      //      .In("header");             
      //          c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
      //        })
      //    .EnableSwaggerUi(c =>
      //        {              
      //          c.InjectJavaScript(thisAssembly, "BabyFace.Api.CustomContent.basic-auth.js");
      //          c.EnableApiKeySupport("apiKey", "header");
      //        });

            GlobalConfiguration.Configuration
         .EnableSwagger(c =>
         {
             c.SingleApiVersion("v1", "BabyFace.Api");
             c.ApiKey("Token")
          .Description("Filling bearer token here")
          .Name("Authorization")
          .In("header");
             c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
         })
         .EnableSwaggerUi("BabyFace-ApiHelp/{*assetPath}", c =>
         {
             c.InjectJavaScript(thisAssembly, "BabyFace.Api.CustomContent.basic-auth.js");
             c.EnableApiKeySupport("apiKey", "header");
         });
        }
  }
}
