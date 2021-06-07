using CafeDAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace CafeDAL.Models
{
    public partial class Suppliers : EntityBase
    {
        [Required]
        public int EDRPOU { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string TypeProduct { get; set; }
        
        [Required, StringLength(30)]
        public string ContactPhone { get; set; }
        
        [Required, StringLength(30)]
        public string ContactEmail { get; set; }
        
        [Required, StringLength(50)]
        public string ContactSite { get; set; }
    }
}
