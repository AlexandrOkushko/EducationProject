using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class Products : EntityBase
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public virtual Suppliers Supplier { get; set; }
    }
}