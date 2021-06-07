using CafeDAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class OrderProducts : EntityBase
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Required]
        public int Count { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Orders Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Products Product { get; set; }
    }
}
