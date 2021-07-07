using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    [Table("Dishes")]
    public partial class Dishes : EntityBase
    {
        [Required, StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string Description { get; set; }

        [Required, Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required] 
        public bool IsActual { get; set; }
    }
}
