using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.Identity
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}