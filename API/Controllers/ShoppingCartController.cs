using AppProva.Entities;
using AppProva.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("shoppingcarts")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {

        public IShoppingCart _shoppingCart;
        

        public ShoppingCartController(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }


        [HttpPost("{userId}")]
        public ShoppingCart Create(Guid userId)
        {
            return _shoppingCart.Creat(userId);
        }


        [HttpDelete("{userId}")]
        public void Delete(Guid userId)
        {
             _shoppingCart.Delete(userId);
        }


        [HttpGet]
        public List<ShoppingCart> GetAll()
        {
            return _shoppingCart.GetAll();
        }

        [HttpGet("{userId}")]
        public ShoppingCart GetShoppingCart(Guid userId)
        {
            return _shoppingCart.Get(userId);
        }


        [HttpPost("{shoppingcartId}/products/{productId}")]
        public ShoppingCart AddProduct(Guid shoppingcartId, Guid productId)
        {
            return _shoppingCart.AddProduct(shoppingcartId, productId);
        }


        [HttpDelete("{shoppingcartId}/products/{productId}")]
        public void DeleteProduct(Guid shoppingcartId, Guid productId)
        {
             _shoppingCart.DeleteProduct(shoppingcartId, productId);
        }



    }
}
