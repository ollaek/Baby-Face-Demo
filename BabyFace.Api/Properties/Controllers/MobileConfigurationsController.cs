using Couponz.Lucky.Domain.Services.Contracts;
using System;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
  public class MobileConfigurationsController : ApiController
  {
    private readonly Lazy<IMobileConfigurationsService> _mobileConfigurationsService;

    public MobileConfigurationsController(Lazy<IMobileConfigurationsService> mobileConfigurationsService)
    {
      _mobileConfigurationsService = mobileConfigurationsService;
    }

    //[Authorize]
    [HttpGet]
    [Route("get-android")]
    public dynamic GetAndroid()
    {
      return _mobileConfigurationsService.Value.GetAndroid();
    }
  //  [Authorize]
    [HttpGet]
    [Route("get-ios")]
    public dynamic GetIOS()
    {
      return _mobileConfigurationsService.Value.GetIOS();
    }
  }
}
