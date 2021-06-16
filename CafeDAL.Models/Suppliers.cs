using CafeDAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace CafeDAL.Models
{
    public partial class Suppliers : EntityBase
    {
        [Required]
        public int EDRPOU { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string TypeProduct { get; set; }
        
        [Required, StringLength(30, MinimumLength = 3)]
        public string ContactPhone { get; set; }
        
        [Required, StringLength(30, MinimumLength = 3)]
        public string ContactEmail { get; set; }
        
        [Required, StringLength(50, MinimumLength = 3)]
        public string ContactSite { get; set; }
    }
}
