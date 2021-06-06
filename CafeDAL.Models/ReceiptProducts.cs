using CafeDAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class ReceiptProducts : EntityBase
    {
        public int ReceiptId { get; set; }

        public int DishId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(ReceiptId))]
        public virtual Receipts Receipt { get; set; }

        [ForeignKey(nameof(DishId))]
        public virtual Dishes Dish { get; set; }
    }
}
