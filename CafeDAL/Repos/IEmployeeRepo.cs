using CafeDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDAL.Repos
{
    interface IEmployeeRepo : IRepo<Employees>
    {
        List<Employees> Search(string searchString);
        List<Employees> GetOnlyChef();
        List<Employees> GetRelatedData();
    }
}
