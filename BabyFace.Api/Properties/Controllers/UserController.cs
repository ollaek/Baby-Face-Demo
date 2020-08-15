using Couponz.Lucky.Domain.Model.Constants;
using Couponz.Lucky.Domain.Model.ViewModels.UserFeedback;
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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly Lazy<ILuckyUserService> _luckyUserService;
        private readonly Lazy<ITransactionService> _transactionService;
        private readonly Lazy<IRequestHeaderHelper> _requestHeaderHelper;
        public UserController(Lazy<ILuckyUserService> luckyUserService,
             Lazy<ITransactionService> transactionService,
             Lazy<IRequestHeaderHelper> requestHeaderHelper)
        {
            _luckyUserService = luckyUserService;
            _transactionService = transactionService;
            _requestHeaderHelper = requestHeaderHelper;

        }

        [HttpPost]
        [AuthorizeUser]
        [Route("send-feedback")]
        public async Task<IHttpActionResult> SendFeedback(SendFeedbackViewModel model)
        {
            await _luckyUserService.Value.SendFeedback(model, HttpContext.Current.User.Identity.GetUserId());
            return Ok(LuckyConstants.ApiSuccessMessage);
        }

        [HttpPut]
        [AuthorizeUser]
        [Route("upgrade-user-account")]
        public async Task<IHttpActionResult> UpgradeFreeToBundle(Guid bundleId)
        {
            await _luckyUserService.Value.UpgradeToPaidBundleAsync(HttpContext.Current.User.Identity.GetUserId(), bundleId);
            return Ok(LuckyConstants.ApiSuccessMessage);
        }

    }
}