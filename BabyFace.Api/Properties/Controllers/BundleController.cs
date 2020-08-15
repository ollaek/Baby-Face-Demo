using Couponz.Lucky.Domain.Model.ViewModels.Bundle;
using Couponz.Lucky.Domain.Model.ViewModels.Offer;
using Couponz.Lucky.Domain.Services.Contracts;
using Couponz.Services.Attributes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
  [Authorize]
  [RoutePrefix("api/bundle")]
  public class BundleController : ApiController
  {
    private readonly Lazy<IBundleService> _bundleService;

    public BundleController(Lazy<IBundleService> bundleService)
    {
      _bundleService = bundleService;
    }

    [Route("default")]
    [HttpGet]
    [AllowAnonymous]
    public async Task<List<OfferPerCategory>> GetDefault(
      [FromUri]string userPhoneNumber,
      [FromUri]int languageId
      )
    {
      return await _bundleService.Value.GetDefault(userPhoneNumber, languageId);
    }

    [Route("get-all")]
    [HttpGet]
    [AllowAnonymous]
    public async Task<List<BundleSummary>> GetAll([FromUri] int languageId)
    {
      return await _bundleService.Value.GetAll(languageId);
    }
        [Route("get-bundle")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<BundleSummary> Get([FromUri] int languageId, [FromUri] string bundleId)
        {
            return await _bundleService.Value.GetBundle(languageId, bundleId);
        }
        [AuthorizeUser]
    [Route("user-bundles")]
    [HttpGet]
    public async Task<List<OfferPerCategory>> GetUserBundles([FromUri] int languageId)
    {
      return await _bundleService.Value.GetUserBundles(HttpContext.Current.User.Identity.GetUserId(), languageId);
    }
  }
}