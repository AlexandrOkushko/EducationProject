using CafeDAL.EF;
using CafeDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CafeDAL.Repos.Interfaces;
using static Microsoft.EntityFrameworkCore.EF;

namespace CafeDAL.Repos
{
    public class EmployeeRepo : BaseRepo<Employees>, IEmployeeRepo
    {
        public EmployeeRepo(CafeContext context) : base(context)
        {
        }
        public List<Employees> GetOnlyChef()
            => Context.Employees.Where(c => c.RoleId == 3).ToList(); // 3 = Chef

        public List<Employees> GetRelatedData()
            => Context.Employees.FromSqlInterpolated($"SELECT * FROM Employees").ToList();

        public List<Employees> Search(string searchString)
            => Context.Employees.Where(c => Functions.Like(c.FirstName, $"%{searchString}%")).ToList();
    }
}
