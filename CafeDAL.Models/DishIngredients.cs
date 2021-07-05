using CafeDAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class DishIngredients : EntityBase
    {
        public int DishId { get; set; }

        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [NotMapped, ForeignKey(nameof(DishId))]
        public virtual Dishes Dish { get; set; }

        [NotMapped, ForeignKey(nameof(ProductId))]
        public virtual Products Products { get; set; }
    }
}
