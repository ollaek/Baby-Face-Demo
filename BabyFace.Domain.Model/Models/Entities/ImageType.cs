using BabyFace.Domain.Model.Contracts;

namespace BabyFace.Domain.Model.Models.Entities
{
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("ImageType")]
  public partial class ImageType : ILookupEntity
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ImageType()
    {
    }

    public int ImageTypeId { get; set; }

    [Column("ImageType")]
    [StringLength(50)]
    public string ImageType1 { get; set; }

    [StringLength(200)]
    public string ImageDirectory { get; set; }
  }
}
