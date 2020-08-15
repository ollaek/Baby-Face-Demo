using BabyFace.Domain.Model.Enums;

namespace BabyFace.Domain.Model.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EnvironmentResource
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Key { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Language { get; set; }

        [StringLength(400)]
        public string Value { get; set; }
    }
}
