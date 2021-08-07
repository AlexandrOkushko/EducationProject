using System.Collections.Generic;
using CafeDAL.Models;

namespace CafeDAL.Repos.Interfaces
{
    public interface IDishRepo : IRepo<Dishes>
    {
        List<Dishes> Search(string searchString);
        List<Dishes> GetActualDishes();
        List<Dishes> GetRelatedData();
    }
}
