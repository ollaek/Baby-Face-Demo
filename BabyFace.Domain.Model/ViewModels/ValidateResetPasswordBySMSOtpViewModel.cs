using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BabyFace.Domain.Model.ViewModels
{
    public class ValidateResetPasswordBySMSOtpViewModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Otp { get; set; }

    }
}
