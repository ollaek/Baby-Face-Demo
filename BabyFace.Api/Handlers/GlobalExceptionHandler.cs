using BabyFace.Domain.Model.ViewModels.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace BabyFace.Api.Handlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        #region Private Members
        private readonly ILog _logger = LogManager.GetLogger(typeof(GlobalExceptionHandler));
        #endregion

    public override void Handle(ExceptionHandlerContext context)
    {
      var exception = context.Exception;
      var result = new ServiceResult();
      if (exception.GetType() == typeof(SqlException))
      {

        result.Status = HttpStatusCode.InternalServerError;
        result.Data = null;
      }
      else
      {
        result.Status = HttpStatusCode.BadRequest;
        result.Data = null;
      }

      switch (exception)
      {
  //      case ServiceValidationErrorsException errorsException:
  //        result.Errors = errorsException.ValidationErrors.ToList();
  //        result.ErrorCode = errorsException.ErrorCode;
  //        break;
  //      case LocalizedException localizedException:
  //        var error = ResponseMessageDictionary.Get(localizedException.Key);
  //        result.Errors = new List<string> { error.Message
  //};
  //        result.ErrorCode = error.Code;
  //        break;
  //      case DevelopmentException developmentException:
  //        result.ErrorCode = developmentException.ErrorCode;
  //        result.Errors = developmentException.DevelopmentErrors.ToList();
  //        result.Status = HttpStatusCode.Forbidden;
  //        break;
  //      case NotFoundException notFound:
  //        result.Errors = notFound.Errors.ToList();
  //        result.Status = HttpStatusCode.NotFound;
  //        break;
        case DbEntityValidationException entityValidationException:
          result.Errors = entityValidationException.EntityValidationErrors
            .SelectMany(_ => _.ValidationErrors)
            .Select(_ => $"{_.PropertyName}, {_.ErrorMessage}")
            .ToList();
          break;
        default:
          result.Errors = GetMessages(exception);
          break;
      }

      try
      {
        result.ErrorCode = result.ErrorCode == null ? "" : result.ErrorCode;
        result.Data = result.Data == null ? new object() : result.Data;
        _logger.Error(result.Errors, exception);

      }
      catch (Exception)
      {
        _logger.Error(result.Errors);


      }
      context.Result = new ErrorMessageResult(context.Request.CreateResponse(result.Status, result));
    }

        private List<string> GetMessages(Exception ex, List<string> output = null)
        {
            output = output ?? new List<string>();

            output.Add(ex.Message);

            if (ex.InnerException != null)
                return GetMessages(ex.InnerException, output);

            return output.Where(_ => _ != "An error occurred while updating the entries. See the inner exception for details.").ToList();
        }

        public class ErrorMessageResult : IHttpActionResult
        {
            private readonly HttpResponseMessage _httpResponseMessage;

            public ErrorMessageResult(HttpResponseMessage httpResponseMessage)
            {
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }
    }
}
