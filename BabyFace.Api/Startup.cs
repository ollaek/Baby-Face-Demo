using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BabyFace.Api.Startup))]

namespace BabyFace.Api
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }
  }
}
