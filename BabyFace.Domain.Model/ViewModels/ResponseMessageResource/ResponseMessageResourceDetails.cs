using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFace.Domain.Model.ViewModels.ResponseMessageResource
{
   public class ResponseMessageResourceDetails
    {
        public string Code { get; set; }
        public string MessageKey { get; set; }
        public string Message { get; set; }
        public byte   LanguageId { get; set; }
    }
}
