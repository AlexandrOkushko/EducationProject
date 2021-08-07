using System.Collections.Generic;
using CafeDAL.Models;

namespace CafeDAL.Repos.Interfaces
{
    public interface IEmployeeRepo : IRepo<Employees>
    {
        List<Employees> Search(string searchString);
        List<Employees> GetOnlyChef();
        List<Employees> GetRelatedData();
    }
}
