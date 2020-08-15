using System.Net;
using System.Web.Http;
using Unity;

namespace BabyFace.Api
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      if (ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12) == false)
      {
        ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;
      }
      UnityConfig.RegisterTypes(new UnityContainer());
      GlobalConfiguration.Configure(WebApiConfig.Register);
      log4net.Config.XmlConfigurator.Configure();

    }
  }
}
