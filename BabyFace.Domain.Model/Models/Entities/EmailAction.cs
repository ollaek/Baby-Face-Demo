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
    [Table("EmailAction")]
   public  class EmailAction : ILookupEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
