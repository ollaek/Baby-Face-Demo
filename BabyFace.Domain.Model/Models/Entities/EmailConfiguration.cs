using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyFace.Domain.Model.Contracts;

namespace BabyFace.Domain.Model.Models.Entities
{
    [Table("EmailConfiguration")]
    public class EmailConfiguration : ILookupEntity
    {

        public int Id { get; set; }
        [Required]
        public int EmailActionId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileUrl { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual EmailAction EmailAction { get; set; }
        public virtual Language Language { get; set; }
    }
}
