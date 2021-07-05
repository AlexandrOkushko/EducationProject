using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class ReadyDishes : EntityBase
    {
        public int DishId { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int Count { get; set; }

        [NotMapped, ForeignKey(nameof(DishId))]
        public virtual Dishes Dish { get; set; }
    }
}
