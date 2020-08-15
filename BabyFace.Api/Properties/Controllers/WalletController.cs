using Couponz.Lucky.Domain.Model.ViewModels.Merchant;
using Couponz.Lucky.Domain.Model.ViewModels.Offer;
using Couponz.Lucky.Domain.Model.ViewModels.Transaction;
using Couponz.Lucky.Domain.Model.ViewModels.UserSavings;
using Couponz.Lucky.Domain.Model.ViewModels.Wallet;
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
  [RoutePrefix("api/Wallet")]
  public class WalletController : ApiController
  {
    private readonly Lazy<ILuckyUserRewardService> _luckyUserRewardService;
      

        public WalletController(Lazy<ILuckyUserRewardService> luckyUserRewardService)
    {
            _luckyUserRewardService = luckyUserRewardService;
        
    }


        
        [AuthorizeUser]
        [HttpGet]
        [Route("get-burned-rewards-wallet-transactions")]
        public async Task<List<RewardProperties>> GetBurnedRewardsAndWalletTransactions(int languageId)
        {
            return await _luckyUserRewardService.Value.GetBurnedRewardsAndWalletTransactions(HttpContext.Current.User.Identity.GetUserId(), languageId);
        }

        [AuthorizeUser]
        [HttpGet]
        [Route("get-wallet-balance")]
        public WalletBalance GetWalletBalance(int languageId)
        {
            return  _luckyUserRewardService.Value.GetSubScribedRewardedWalletBalance(HttpContext.Current.User.Identity.GetUserId(), languageId);
        }

        [AuthorizeUser]
        [HttpGet]
        [Route("get-expired-rewards")]
        public async Task<List<RewardProperties>> GetExpiredRewards(int languageId)
        {
            return await _luckyUserRewardService.Value.GetExpiredRewards(HttpContext.Current.User.Identity.GetUserId(), languageId);
        }

        [AuthorizeUser]
        [HttpGet]
        [Route("get-merchant-list")]
        public async Task<List<FinanceMerchantProfile>> GetWalletMerchantsList(int languageId)
        {
            return await _luckyUserRewardService.Value.GetWalletMerchantsList(HttpContext.Current.User.Identity.GetUserId(), languageId);
        }
        [AuthorizeUser]
        [HttpGet]
        [Route("get-rewards")]
        public async Task<List<RewardProperties>> GetUserRewards(int languageId)
        {
            return await _luckyUserRewardService.Value.GetRewards(HttpContext.Current.User.Identity.GetUserId(), languageId);
        }

    }
}