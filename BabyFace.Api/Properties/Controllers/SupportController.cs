using Couponz.Lucky.Domain.Model.Constants;
using Couponz.Lucky.Domain.Model.ViewModels.FQAsQuestions;
using Couponz.Lucky.Domain.Model.ViewModels.UserFeedback;
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
  [RoutePrefix("api/support")]
  public class SupportController : ApiController
  {
    private readonly Lazy<IFQAsQuestionResourceService> _fqaService;

    public SupportController(Lazy<IFQAsQuestionResourceService> fqaService)
    {
            _fqaService = fqaService;
    }

    [HttpGet]
        [AllowAnonymous]
        [Route("get-fqas")]
    public async Task<List<FQAsQuestionsAndAnswersVM>> GetFQAsQuestion(int?languageId)
    {
      await _fqaService.Value.Get(languageId);
            return await _fqaService.Value.Get(languageId);
        }
  }
}