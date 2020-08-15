namespace BabyFace.Domain.Model.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RefreshToken
    {
        [StringLength(100)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(50)]
        public string ClientId { get; set; }

        public DateTime? IssuedUtc { get; set; }

        public DateTime? ExpiresUtc { get; set; }

        [StringLength(500)]
        public string ProtectedTicket { get; set; }
    }
}
