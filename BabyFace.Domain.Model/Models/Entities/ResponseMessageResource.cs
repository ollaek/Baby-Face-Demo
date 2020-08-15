using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BabyFace.Domain.Model.Models.Entities
{
  [Table("ResponseMessageResource")]
  public class ResponseMessageResource
  {

    [Key]
    public int Id { get; set; }
    public string Code { get; set; }
    public string MessageKey { get; set; }
    public string Message { get; set; }
    [ForeignKey("Language")]
    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

  }
}
