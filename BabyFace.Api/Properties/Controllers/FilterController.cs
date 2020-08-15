using Couponz.Lucky.Domain.Commands.Contracts;
using Couponz.Lucky.Domain.Model.ViewModels.Filter;
using Couponz.Lucky.Domain.Model.ViewModels.Search;
using Couponz.Lucky.Domain.Services.ServiceFactories.Contracts;
using Couponz.Services.Attributes;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
  [Authorize]
  [RoutePrefix("api/Filter")]
  public class FilterController : ApiController
  {
    private readonly Lazy<ISearchCommand> _command;
        private readonly Lazy<IFilterFactoryService> _filterFactory;

        public FilterController(Lazy<ISearchCommand> command, Lazy<IFilterFactoryService> filterFactory)
        {
            _command = command;
            _filterFactory = filterFactory;
        }

        ////[AuthorizeUser]
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("filter-offers")]
        //public async Task<GlobalSearchDetails> Filter(FilterInputModel model)
        //{
        //    return await _command.Value.GlobalFilter(model);
        //}

        [AllowAnonymous]
        [HttpGet]
        [Route("filter-lookups")]
        public async Task<FilterScreenLookups> GetFilterScreenLookup(int? languageId)
        {
            return await _filterFactory.Value.GetFilterScreenLookupAsync(languageId);
        }
    }
}