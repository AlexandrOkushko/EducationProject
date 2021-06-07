using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class EmployeeMisconducts : EntityBase
    {
        public int EmployeeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Misconduct { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employees Employee { get; set; }
    }
}
