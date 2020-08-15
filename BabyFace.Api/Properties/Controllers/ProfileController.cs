using Couponz.Lucky.Domain.Model.ViewModels.UserProfile;
using Couponz.Lucky.Domain.Providers;
using Couponz.Lucky.Domain.Services.Contracts;
using Couponz.Services.Attributes;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
  [Authorize]
  [RoutePrefix("api/Profile")]
  public class ProfileController : ApiController
  {
    private readonly Lazy<ILuckyUserService> _luckyUserService;
    private readonly Lazy<IRequestHeaderHelper> _requestHeaderHelper;

    public ProfileController(Lazy<ILuckyUserService> luckyUserService, Lazy<IRequestHeaderHelper> requestHeaderHelper)
    {
      _luckyUserService = luckyUserService;
      _requestHeaderHelper = requestHeaderHelper;
    }

    [HttpGet]
    [AuthorizeUser]
    [Route("user-profile")]
    public async Task<UserProfileProperties> Get()
    {
      var languageId = _requestHeaderHelper.Value.GetLanguageFromHeader(Request);
      return await _luckyUserService.Value.GetProfile(HttpContext.Current.User.Identity.GetUserId(), languageId);
    }
  }
}
