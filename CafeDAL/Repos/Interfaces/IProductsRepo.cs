using System.Collections.Generic;
using CafeDAL.Models;

namespace CafeDAL.Repos.Interfaces
{
    public interface IProductsRepo : IRepo<Products>
    {
        List<Products> Search(string searchString);
        List<Products> GetProductsBySupplierId(int id);
        List<Products> GetRelatedData();
    }
}
