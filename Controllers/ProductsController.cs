using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _context;

        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ProductsController));

        /*public ProductsController()
        { }*/
        public ProductsController(IProductRepo context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            log.Info("Get Products Detail method is invoked");
            return _context.GetProduct();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temppro = _context.GetById(id);


            if (temppro == null)
            {
                log.Info("id not found");
                return NotFound();
            }
            log.Info("Get Product with id "+id+" is invoked");
            return Ok(temppro);
        }


        [HttpPost("PostProduct")]

        public async Task<IActionResult> PostProduct(Product prod)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = await _context.PostProduct(prod);

            log.Info("Post Products Detail method is invoked");
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Product product)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var editedProduct = await _context.PutProduct(id, product);

            log.Info(" Product with id "+id+"got updated");
            return Ok(editedProduct);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedProduct = await _context.DeleteProduct(id);
            log.Info(" Product with id " + id + "got deleted");
            return Ok(deletedProduct);
        }
    }
}
