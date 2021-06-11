using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repository
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProduct();
      
        Product GetById(int id);

        Task<Product> PostProduct(Product prod);

        Task<Product> DeleteProduct(int id);

        Task<Product> PutProduct(int id, Product item);
    }
}
