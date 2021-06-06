using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class ProductsOrders
    {
        //[Key, Column(Order = 0)]
        public int ProductId { get; set; }

        //[Key, Column(Order = 1)]
        public int OrderId { get; set; }

        [Required]
        public int Count { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Products Product { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Orders Order { get; set; }
    }
}
