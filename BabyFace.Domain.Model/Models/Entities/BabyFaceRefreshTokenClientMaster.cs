using BabyFace.Domain.Model.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyFace.Domain.Model.Models.Entities
{
  [Table("BabyFaceRefreshTokenClientMaster")]
  public class BabyFaceRefreshTokenClientMaster 
  {
    [Key]
    public int ClientKeyId { get; set; }
    [Required]
    public string ClientID { get; set; }
    [Required]
    public string ClientSecret { get; set; }
    [Required]
    public string ClientName { get; set; }
    [Required]
    public bool Active { get; set; }
    [Required]
    public int RefreshTokenLifeTime { get; set; }
    [Required]
    public string AllowedOrigin { get; set; }
       
    }
}
