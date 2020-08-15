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
  [RoutePrefix("api/Location")]
  public class LocationController : ApiController
  {

        private readonly Lazy<IFilterFactoryService> _filterFactory;

        public LocationController( Lazy<IFilterFactoryService> filterFactory)
        {
           
            _filterFactory = filterFactory;
        }

      

        [AllowAnonymous]
        [HttpGet]
        [Route("get-Regions")]
        public async Task<FilterScreenLookups> GetRegionsByCityId(int cityId,int? languageId)
        {
            return await _filterFactory.Value.GetFilterScreenLookupAsync(languageId);
        }
    }
}