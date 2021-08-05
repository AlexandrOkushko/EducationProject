using CafeDAL.EF;
using CafeDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.EF;

namespace CafeDAL.Repos
{
    public class DishRepo : BaseRepo<Dishes>, IDishRepo
    {
        public DishRepo(CafeContext context) : base(context)
        {
        }

        public List<Dishes> Search(string searchString)
            => Context.Dishes.Where(c => Functions.Like(c.Name, $"%{searchString}%")).ToList();

        public override List<Dishes> GetAll()
            => GetAll(x => x.Id, true).ToList();

        public List<Dishes> GetActualDishes()
            => GetSome(x => x.IsActual == true);

        public List<Dishes> GetRelatedData()
            => Context.Dishes.FromSqlInterpolated($"SELECT * FROM Dishes").ToList();
    }
}
