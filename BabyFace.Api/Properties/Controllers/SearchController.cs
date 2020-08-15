using Couponz.Lucky.Domain.Commands.Contracts;
using Couponz.Lucky.Domain.Model.ViewModels.Search;
using Couponz.Services.Attributes;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
  [Authorize]
  [RoutePrefix("api/Search")]
  public class SearchController : ApiController
  {
    private readonly Lazy<ISearchCommand> _command;

    public SearchController(Lazy<ISearchCommand> command)
    {
      _command = command;
    }

    //[AuthorizeUser]
    [AllowAnonymous]
    [HttpPost]
    [Route("global-search")]
    public async Task<GlobalSearchDetails> Search(SearchInputModel model)
    {
      return await _command.Value.GlobalSearch(model);
    }
  }
}