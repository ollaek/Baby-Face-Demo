using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
    public class CorrectPhoneNumberInput
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string NewNumber { get; set; }

        [Required]
        public string OldNumber { get; set; }

        [Required]
        public int LanguageId { get; set; }
    }
}
