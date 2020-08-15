using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFace.Domain.Model.ViewModels.Email
{
    public class EmailConfigurationViewModel
    {
        public string CallbackUrl { get; set; }
        public string ActionName { get; set; }
        public string Language { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
    }
}
