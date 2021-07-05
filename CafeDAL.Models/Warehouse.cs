using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class Warehouse : EntityBase
    {
        public int ProductId { get; set; }

        [Required, Display(Name = "Production Date")]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int Count { get; set; }

        [NotMapped, ForeignKey(nameof(ProductId))]
        public virtual Products Product { get; set; }
    }
}
