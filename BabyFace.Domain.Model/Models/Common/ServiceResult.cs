using System.Collections.Generic;
using System.Net;

namespace BabyFace.Domain.Model.ViewModels.Common
{
  public class ServiceResult
  {
        public ServiceResult()
        {
            //ErrorCode = "";
            //Errors = new List<string>();
        }
    public HttpStatusCode Status { get; set; }
    public object Data { get; set; }
    public List<string> Errors { get; set; }
    public string ErrorCode { get; set; }
  }
}
