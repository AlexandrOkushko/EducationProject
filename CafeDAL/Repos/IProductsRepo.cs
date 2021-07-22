using CafeDAL.Models;
using System.Collections.Generic;

namespace CafeDAL.Repos
{
    public interface IProductsRepo : IRepo<Products>
    {
        List<Products> Search(string searchString);
        List<Products> GetProductsBySupplierId();
        List<Products> GetRelatedData();
    }
}
