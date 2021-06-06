using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class Warehouse : EntityBase
    {
        [Required]
        public int ProductId { get; set; }

        [Required, Display(Name = "DeliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public int Count { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Products Product { get; set; }
    }
}
