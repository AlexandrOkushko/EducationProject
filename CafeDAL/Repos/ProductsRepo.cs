using CafeDAL.EF;
using CafeDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CafeDAL.Repos.Interfaces;
using static Microsoft.EntityFrameworkCore.EF;

namespace CafeDAL.Repos
{
    public class ProductsRepo : BaseRepo<Products>, IProductsRepo
    {
        public ProductsRepo(CafeContext context) : base(context)
        {
        }

        public List<Products> GetProductsBySupplierId(int id)
        => Context.Products.Where(c => c.SupplierId == id).ToList(); // 1 = Main supplier

        public List<Products> GetRelatedData()
            => Context.Products.FromSqlInterpolated($"SELECT * FROM Products").ToList();

        public List<Products> Search(string searchString)
            => Context.Products.Where(c => Functions.Like(c.Name, $"%{searchString}%")).ToList();
    }
}
