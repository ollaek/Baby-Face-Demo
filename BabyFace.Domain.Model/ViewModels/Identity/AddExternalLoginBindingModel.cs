using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.Identity
{
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}
