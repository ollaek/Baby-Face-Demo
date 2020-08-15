using BabyFace.Domain.Model.Constants;
using BabyFace.Domain.Model.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace BabyFace.Api.Handlers
{
  public class ResponseHandler : DelegatingHandler
  {
    //protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //{
    //  if (ResponseMessageDictionary.isEmpty())
    //  {
    //    var responseMessageResourceService = (IResponseMessageResourceService)UnityConfig.Container.Resolve(typeof(IResponseMessageResourceService));
    //    var responseMessageResourcesDictionary = responseMessageResourceService.Get().GroupBy(_ => _.MessageKey)
    //      .ToDictionary(_ => _.Key, _ => _.ToDictionary(m => m.LanguageId, m => new ErrorCode { Message = m.Message, Code = m.Code }));
    //    ResponseMessageDictionary.Set(responseMessageResourcesDictionary);
    //  }

    //  if (!request.RequestUri.ToString().Contains("/api"))
    //    return await base.SendAsync(request, cancellationToken);
    //  ResponseMessageDictionary.SetLanguage(request.Headers.Contains("language")
    //    ? int.Parse(request.Headers.GetValues("language").Single())
    //    : 1);
    //  var response = await base.SendAsync(request, cancellationToken);

    //  if (response.StatusCode == HttpStatusCode.Unauthorized && response.TryGetContentValue<object>(out var result))
    //  {
    //    return request.CreateResponse(HttpStatusCode.Unauthorized,
    //      new ServiceResult { Status = HttpStatusCode.Unauthorized, Errors = new List<string> { result.GetPropValue("Message").ToString() } });
    //  }

    //  if (response.TryGetContentValue<object>(out var content))
    //  {
    //    return request.CreateResponse(HttpStatusCode.OK,
    //      new ServiceResult { Status = HttpStatusCode.OK, Data = content });
    //  }

    //  return request.CreateResponse(HttpStatusCode.OK,
    //    new ServiceResult { Status = HttpStatusCode.OK, Data = BabyFaceConstants.ApiSuccessMessage });
    //}
  }
}
