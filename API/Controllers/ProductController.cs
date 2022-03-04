using AppProva.Entities;
using AppProva.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProduct _product;
        public ILogger _logger;

        public ProductController(IProduct product, ILoggerFactory loggerFactory)
        {
            _product = product;
            _logger = loggerFactory.CreateLogger("ProductControllerCategory");
        }

        
         
        [HttpGet("{productId}")]
        public Product GetProduct(Guid productId)
        {
            return _product.GetProduct(productId);
        }

        
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            _logger.LogInformation("Return products!");
            var products = _product.GetAll();
            return products;
        }

        
        
        [HttpPost]
        public Product Insert(Product product)
        {
            return _product.Insert(product);
        }


        [HttpDelete("{productId}")]
        public void Delete(Guid productId)
        {
            _product.Delete(productId);
        }

        
        [HttpPut("{productId}")]
        public Product Update(Guid productId)
        {
            return _product.Update(productId);
        }





    }
}
