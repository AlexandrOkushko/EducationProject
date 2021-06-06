using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class ReadyDish : EntityBase
    {
        public int DishId { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [ForeignKey(nameof(DishId))]
        public virtual Dishes Dish { get; set; }
    }
}
