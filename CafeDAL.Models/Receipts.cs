using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CafeDAL.Models
{
    public partial class Receipts : EntityBase
    {
        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
