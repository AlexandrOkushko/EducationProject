using CafeDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDAL.Models
{
    public partial class Gender : EntityBase
    {
        [Required, StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
