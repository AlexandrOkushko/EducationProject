using CafeDAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace CafeDAL.Models
{
    public partial class Roles : EntityBase
    {
        [Required]
        public string Name { get; set; }
    }
}
