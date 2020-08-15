using Microsoft.AspNet.Identity.EntityFramework;

namespace BabyFace.Domain.Model.Models.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LuckyUserClaim")]
    public class BabyFaceUserClaim : IdentityUserClaim<string>
    {
    }
}
