using CafeDAL.Models;
using System.Collections.Generic;

namespace CafeDAL.Repos
{
    public interface IDishRepo : IRepo<Dishes>
    {
        List<Dishes> Search(string searchString);
        List<Dishes> GetActualDishes();
        List<Dishes> GetRelatedData();
    }
}
