using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFace.Domain.Model.ViewModels
{
    public class RegisterationOtpInfoViewModel
    {
        [Required]
        public DateTime OtpExpiryTime { get; set; }
        [Required]
        public string Otp { get; set; }

    }
}
