using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyFace.Domain.Model.Models.Entities
{
  [Table("BabyFaceRefreshToken")]
  public class BabyFaceRefreshToken
  {
    [Key]
    public string Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string ClientId { get; set; }
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [MaxLength(50)]
    public string Subject { get; set; }
    public DateTime IssuedUtc { get; set; }
    public DateTime ExpiresUtc { get; set; }
    public string ProtectedTicket { get; set; }




  }
}
