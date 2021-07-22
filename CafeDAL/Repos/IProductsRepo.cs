using CafeDAL.Models;
using System.Collections.Generic;

namespace CafeDAL.Repos
{
    public interface IProductsRepo : IRepo<Products>
    {
        List<Products> Search(string searchString);
        List<Products> GetProductsBySupplierId(int id);
        List<Products> GetRelatedData();
    }
}
