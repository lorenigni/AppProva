using AppProva.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProva.Repository.Impl
{
    public class ShoppingCartRepository : IShoppinCartRepository
    {

        public List<ShoppingCart> _shoppincharts;
        public ILogger<ShoppingCartRepository> _logger;


        public ShoppingCartRepository(ILogger<ShoppingCartRepository> logger)
        {
            _shoppincharts = new List<ShoppingCart>();
            _logger = logger;
        }


        public List<ShoppingCart> GetAll()
        {
            _logger.LogInformation("Returning all the shoppingcarts");
            return _shoppincharts;
        }


        public ShoppingCart? Creat(Guid userId)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.UserId = userId;
            cart.Id = Guid.NewGuid();
            int count = 0;
            for (int i = 0; i < _shoppincharts.Count; i++)
            {
                if (_shoppincharts[i].UserId == cart.UserId)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                _shoppincharts.Add(cart);
                return cart;
            }
            else
            {
                _logger.LogWarning("A user with that id already exists");
                return null;
            }
           


        }


        public void Delete(Guid userId)
        {
            try
            {
                checkId(userId);

            }
            catch (InvalidIdException ex)
            {
                _logger.LogWarning($"No shoppincart is associated with the user: {userId}");
                Console.WriteLine(ex.Message);
            }
            _shoppincharts = _shoppincharts.Where(ShoppingCart => ShoppingCart.UserId != userId).ToList();


        }


        public ShoppingCart? GetShoppingcart(Guid userId)
        {

            try
            {
                checkId(userId);
            }

            catch (Exception)
            {
                _logger.LogWarning($"No shoppincart is associated with the user: {userId}");
                return null;
            }
            _shoppincharts = _shoppincharts.Where(x => x.UserId == userId).ToList();
            return _shoppincharts.FirstOrDefault();


        }


        public ShoppingCart? GetShoppingcartById(Guid shoppincgartId)
        {

            try { checkIdShop(shoppincgartId); }
            catch (Exception)
            {
                _logger.LogWarning($"Invalid id");
                return null;
            }

            _shoppincharts = _shoppincharts.Where(x => x.Id == shoppincgartId).ToList();
            return _shoppincharts.FirstOrDefault();

        }


        public void checkId(Guid id)
        {
            var count = 0;
            for (int i = 0; i < _shoppincharts.Count; i++)
            {
                if (_shoppincharts[i].UserId == id)
                {
                    count++;

                }
            }
            if (count == 0) { throw new InvalidIdException(); }
        }

        public void checkIdShop(Guid id)
        {
            var count = 0;
            for (int i = 0; i < _shoppincharts.Count; i++)
            {
                if (_shoppincharts[i].Id == id) { count++; }

            }
            if (count == 0) { throw new Exception(); }
        }

    }
}
