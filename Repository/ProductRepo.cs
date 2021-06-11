using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly shopContext _context;


        public ProductRepo()
        {

        }
        public ProductRepo(shopContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProduct()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            Product bk = _context.Products.FirstOrDefault(P => P.Pid == id);
            return bk;
        }

        public async Task<Product> PostProduct(Product prod)
        {

            await _context.Products.AddAsync(prod);
            _context.SaveChanges();
            return prod;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            Product sp = await _context.Products.FindAsync(id);
            if (sp == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.Remove(sp);
                _context.SaveChanges();
            }
            return sp;
        }

        public async Task<Product> PutProduct(int id, Product item)
        {
            Product Sp = await _context.Products.FindAsync(id);
            //Sp.Pid = item.Pid;
            Sp.ProductName = item.ProductName;
            Sp.Price = item.Price;
            Sp.Quantity = item.Quantity;
            Sp.Description = item.Description;
            _context.SaveChanges();
            return Sp;
        }
    }
}
