using Couponz.Lucky.Domain.Model.Constants;
using Couponz.Lucky.Domain.Model.ViewModels.Category;
using Couponz.Lucky.Domain.Model.ViewModels.Offer;
using Couponz.Lucky.Domain.Model.ViewModels.Search;
using Couponz.Lucky.Domain.Providers;
using Couponz.Lucky.Domain.Services.Contracts;
using Couponz.Services.Attributes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace Couponz.Lucky.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/offer")]
    public class OfferController : ApiController
    {
        private readonly Lazy<IOfferService> _offerService;
        private readonly Lazy<IFavoriteOfferService> _favoriteOfferService;
        private readonly Lazy<ICouponzDataService> _couponzDataService;
        private readonly Lazy<ITransactionService> _transactionService;
        private readonly Lazy<ILuckyUserRewardService> _luckyUserRewardService;
        private readonly Lazy<IRequestHeaderHelper> _requestHeaderHelper;
        public OfferController(
            Lazy<IOfferService> offerService,
            Lazy<IFavoriteOfferService> favoriteOfferService,
            Lazy<ICouponzDataService> couponzDataService,
             Lazy<ITransactionService> transactionService,
             Lazy<ILuckyUserRewardService> luckyUserRewardService,
             Lazy<IRequestHeaderHelper> requestHeaderHelper
            )
        {
            _offerService = offerService;
            _favoriteOfferService = favoriteOfferService;
            _couponzDataService = couponzDataService;
            _transactionService = transactionService;
            _luckyUserRewardService = luckyUserRewardService;
            _requestHeaderHelper = requestHeaderHelper;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("regular-offers")]
        public async Task<List<OfferDetails>> GetRegularOffers(string userPhoneNumber, int? languageId)
        {
            return await _offerService.Value.GetRegular(userPhoneNumber, languageId);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("get-favorite-offers")]
        public async Task<List<OfferDetails>> GetFavoriteOffers(string userId, string userPhoneNumber, int? languageId, int? skip, int? take)
        {
            return await _offerService.Value.GetFavoriteOffers(userId, userPhoneNumber, languageId, skip, take);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("get-offer")]
        public async Task<OfferDetails> GetOffer(int offerId, string userPhoneNumber, int? languageId)
        {
            return await _offerService.Value.GetOffer(offerId, userPhoneNumber, languageId);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("regular-offers-by-geolocation")]
        public async Task<List<OfferDetails>> GetRegularOffers(GetOffersInputModel model)
        {
            return await _offerService.Value.GetRegular(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("get-offers")]
        public async Task<OfferDetialsWithRemianing> GetOffersWithFilters(GetOffersInputModel model)
        {
            var languageId = _requestHeaderHelper.Value.GetLanguageFromHeader(Request);
            return await _offerService.Value.GetRegularWithRemaining(model);
        }
        [HttpPost]
        [AuthorizeUser]
        [Route("add-to-favorite")]
        public async Task<IHttpActionResult> AddOfferToFavorite(int offerId)
        {
            var favoriteOfferInputViewModel = new FavoriteOfferInputViewModel { OfferId = offerId, UserId = HttpContext.Current.User.Identity.GetUserId() };
            await _favoriteOfferService.Value.AddOfferToFavorite(favoriteOfferInputViewModel);
            return Ok(LuckyConstants.ApiSuccessMessage);
        }

        [HttpPut]
        [AuthorizeUser]
        [Route("remove-from-favorite")]
        public async Task<IHttpActionResult> RemoveOfferFromFavorite(int offerId)
        {
            var favoriteOfferInputViewModel = new FavoriteOfferInputViewModel { OfferId = offerId, UserId = HttpContext.Current.User.Identity.GetUserId() };
            await _favoriteOfferService.Value.RemoveOfferFromFavorite(favoriteOfferInputViewModel);
            return Ok(LuckyConstants.ApiSuccessMessage);
        }

        [HttpPost]
        [AuthorizeUser]
        [Route("redeem-offer")]
        public async Task<dynamic> RedeemOfferAsync(string msisdn, int offerId, string pinCode, int? languageId)
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();
            string offerNumber;
            // check if user is eligible to burn offer
            _offerService.Value.ValidateOfferBeforeRedeemWithPin(offerId, pinCode, msisdn, userId, out offerNumber);
            // burn the offer
            dynamic result = _couponzDataService.Value.RedeemOfferByPinCode(offerNumber, pinCode, msisdn, userId, languageId);
            var errorCode = result["ErrorCode"];
            // throw exception if burn failed
            if (int.Parse(errorCode.ToString()) != 0)
            {
                throw new Exception(result["Message"]);
            }
            var transactionId = int.Parse(result["TransactionId"].ToString());
            // updaate transaction with lucky userID
            await _transactionService.Value.UpdateTransactionWithLuckyUserId(transactionId, userId);
            //  check if user is referred && this is his First Transaction to give rewards
            await _luckyUserRewardService.Value.RewardReferalUser(userId, msisdn, languageId);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("search")]
        public async Task<List<OfferDetails>> SearchOffer(SearchInputModel model)
        {
            return await _offerService.Value.SearchOffers(model);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("category")]

        public async Task<List<CategoryDetails>> GetActiveOffersCategories(int languageId)
        {
            return await _offerService.Value.GetActiveOffersCategories(languageId);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //[Route("get-remaining-offers")]

        //public async Task<string> GetRemainingOffers(string userPhoneNumber)
        //{
        //    var languageId = _requestHeaderHelper.Value.GetLanguageFromHeader(Request);
        //    return await _transactionService.Value.GetCountOfRemainingOffersPerOffer(userPhoneNumber, 0, languageId);
        //}
    }

}