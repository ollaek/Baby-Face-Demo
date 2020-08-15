using Couponz.Lucky.Domain.Model.Models.Entities;
using Couponz.Lucky.Domain.Model.ViewModels.Category;
using Couponz.Lucky.Domain.Model.ViewModels.Lookups;
using Couponz.Lucky.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
    [RoutePrefix("api/lookup")]
    public class LookupController : ApiController
    {
        private readonly Lazy<ILookupService<Language>> _languageService;
        private readonly Lazy<ILookupService<AccountType>> _accountTypeService;
        private readonly Lazy<ILookupService<City>> _cityService;
        private readonly Lazy<ILookupService<Gender>> _genderService;
        private readonly Lazy<ILookupService<OfferType>> _offerTypeService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ILookupService> _lookupService;

        public LookupController(
          Lazy<ILookupService<Language>> languageService,
          Lazy<ILookupService<AccountType>> accountTypeService,
          Lazy<ILookupService<City>> cityService,
          Lazy<ILookupService<Gender>> genderService,
          Lazy<ILookupService<OfferType>> offerTypeService,
          Lazy<ICategoryService> categoryService,
          Lazy<ILookupService> lookupService
          )
        {
            _languageService = languageService;
            _accountTypeService = accountTypeService;
            _cityService = cityService;
            _genderService = genderService;
            _offerTypeService = offerTypeService;
            _categoryService = categoryService;
            _lookupService = lookupService;
        }

        [Route("languages")]
        [HttpGet]
        public async Task<List<LookupModel<int>>> GetLanguages()
        {
            return (await _languageService.Value.Get())
              .Select(_ => new LookupModel<int> { Id = _.LanguageId, Name = _.Language1 })
              .ToList();
        }

        [Route("account-type")]
        [HttpGet]
        public async Task<List<LookupModel<Guid>>> GetAccountTypes()
        {
            return (await _accountTypeService.Value.Get())
              .Select(_ => new LookupModel<Guid> { Id = _.Id, Name = _.Name })
              .ToList();
        }

        [Route("city")]
        [HttpGet]
        public async Task<List<LookupModel<int>>> GetCities()
        {
            return (await _cityService.Value.Get())
              .Select(_ => new LookupModel<int> { Id = _.CityId, Name = _.CityName })
              .ToList();
        }

        [Route("gender")]
        [HttpGet]
        public async Task<List<LookupModel<Guid>>> GetGenders()
        {
            return (await _genderService.Value.Get())
              .Select(_ => new LookupModel<Guid> { Id = _.Id, Name = _.Name })
              .ToList();
        }

        [Route("offer-type")]
        [HttpGet]
        public async Task<List<LookupModel<int>>> GetOfferTypes()
        {
            return (await _offerTypeService.Value.Get())
              .Select(_ => new LookupModel<int> { Id = _.OfferTypeId, Name = _.OfferType1 })
              .ToList();
        }

        [Route("category")]
        [HttpGet]
        public async Task<List<CategoryDetails>> GetCategories(int languageId)
        {
            return await _categoryService.Value.GetByLanguageId(languageId);
        }

        [HttpPost]
        [Route("get-by-name")]
        public Dictionary<string, dynamic> GetByName(string[] lookupNames)
        {
            return _lookupService.Value.GetByName(lookupNames);
        }

        [HttpGet]
        [Route("get-all")]
        public Dictionary<string, dynamic> GetAll()
        {
            return _lookupService.Value.GetAll();
        }

        [HttpGet]
        [Route("get-lookup-names")]
        public List<string> GetLookupNames()
        {
            return _lookupService.Value.GetLookupNames();
        }
    }
}