using CafeDAL.Models;
using System.Collections.Generic;

namespace CafeDAL.Repos
{
    public interface IEmployeeRepo : IRepo<Employees>
    {
        List<Employees> Search(string searchString);
        List<Employees> GetOnlyChef();
        List<Employees> GetRelatedData();
    }
}
