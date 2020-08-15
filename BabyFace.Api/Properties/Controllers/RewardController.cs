using Couponz.Lucky.Domain.Model.ViewModels.Offer;
using Couponz.Lucky.Domain.Model.ViewModels.Transaction;
using Couponz.Lucky.Domain.Model.ViewModels.UserSavings;
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
  [RoutePrefix("api/Reward")]
  public class RewardController : ApiController
  {
    private readonly Lazy<ILuckyUserRewardService> _luckyUserRewardService;
      

        public RewardController(Lazy<ILuckyUserRewardService> luckyUserRewardService)
    {
            _luckyUserRewardService = luckyUserRewardService;
        
    }


        [AuthorizeUser]
        [HttpGet]
        [Route("Get-Sent-Rewards")]
        public async Task<List<RewardProperties>> GetUserRewards( int languageId)
        {
            return await _luckyUserRewardService.Value.GetRewards(HttpContext.Current.User.Identity.GetUserId(), languageId);
        }
        // Task<List<RewardProperties>> GetBurnedRewards(string userId, int languageId)
       
    }
}