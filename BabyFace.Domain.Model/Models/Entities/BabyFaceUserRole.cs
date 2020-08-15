namespace BabyFace.Domain.Model.Models.Entities
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BabyFaceUserRole")]
    public class BabyFaceUserRole : IdentityRole<string, RoleForBabyFaceUser>
    {
    }
}
