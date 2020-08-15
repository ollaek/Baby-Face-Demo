using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
    public class ValidateRegistrationViewModel
    {
        public string MobileNumber { get; set; }
        public string RegistrationOtp { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string FcmToken { get; set; }
        public string DeviceId { get; set; }
        public string MobileVersion { get; set; }
        public int? PlatformId { get; set; }
        public int? LanguageId { get; set; }
    }
}
