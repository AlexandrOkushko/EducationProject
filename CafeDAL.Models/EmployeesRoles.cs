using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    public partial class EmployeesRoles
    {
        public int EmployeeId { get; set; }

        public int RoleId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employees Employee { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Roles Role { get; set; }
    }
}
