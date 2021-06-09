using CafeDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.EF;

namespace CafeDAL.Repos
{
    public class EmloyeeRepo : BaseRepo<Employees>, IEmployeeRepo
    {
        public List<Employees> GetOnlyChef()
            => Context.Employees.Where(c => c.RoleId == 3).ToList(); // 3 = Chef

        public List<Employees> GetRelatedData()
            => Context.Employees.FromSqlInterpolated($"SELECT * FROM Employees").ToList();


        public List<Employees> Search(string searchString)
            => Context.Employees.Where(c => Functions.Like(c.FirstName, $"%{searchString}%")).ToList();
    }
}
