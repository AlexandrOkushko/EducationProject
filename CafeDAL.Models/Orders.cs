using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CafeDAL.Models
{
    public partial class Orders : EntityBase
    {
        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
