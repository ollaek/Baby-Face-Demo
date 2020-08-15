using Couponz.Lucky.Domain.Model.ViewModels.Lookups;
using Couponz.Lucky.Domain.Model.ViewModels.Merchant;
using Couponz.Lucky.Domain.Model.ViewModels.Search;
using Couponz.Lucky.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/merchant")]
    public class MerchantController : ApiController
    {
        private readonly Lazy<IMerchantService> _merchantService;
        private readonly Lazy<IOfferService> _offerService;

        public MerchantController(Lazy<IMerchantService> merchantService, Lazy<IOfferService> offerService)
        {
            _merchantService = merchantService;
            _offerService = offerService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("profile")]
        public async Task<MerchantProfileViewModel> GetMerchantProfile(MerchantProfileInputModel model)
        {
            return await _merchantService.Value.GetProfile(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("premium")]
        public async Task<List<MerchantPerCategory>> GetPremium(PremiumMerchantsInput model)
        {
            return await _merchantService.Value.GetPremium(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("search")]
        public  List<MerchantSearchViewModel> SearchMerchant(SearchInputModel model)
        {
            return  _merchantService.Value.SearchMerchant(model);
        }
        [Route("get-merchant-list")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<LookupModel<int>>> GetMerchants(int languageId)
        {
            return await _offerService.Value.GetMerchantsList( languageId);
        }
    }
}