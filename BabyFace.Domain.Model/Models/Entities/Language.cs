using BabyFace.Domain.Model.Contracts;

namespace BabyFace.Domain.Model.Models.Entities
{
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("Language")]
  public partial class Language : ILookupEntity
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Language()
    {
    }

    public int LanguageId { get; set; }

    [Column("Language")]
    [StringLength(50)]
    public string Language1 { get; set; }
  }
}
