using Microsoft.AspNet.Identity.EntityFramework;

namespace BabyFace.Domain.Model.Models.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BabyFaceUserLogin")]
    public class BabyFaceUserLogin : IdentityUserLogin<string>
    {
    }
}
