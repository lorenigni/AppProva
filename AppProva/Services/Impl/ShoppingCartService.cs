using AppProva.Entities;
using AppProva.Repository;
using AppProva.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProva.Services.Impl
{
    public class ShoppingCartService : IShoppingCart
    {

        public IShoppinCartRepository shoppingCartRepository { get; }
        public List<Guid> _products { get; set; }
        public ShoppingCart shoppingCart { get; set; }


        

        
        public ShoppingCartService(IShoppinCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this._products = new List<Guid>();
            this.shoppingCart = new ShoppingCart();
            
                      
        }

        public List<ShoppingCart> GetAll()
        {
            return shoppingCartRepository.GetAll();
        }

        public ShoppingCart Creat(Guid userId)
        {
            return shoppingCartRepository.Creat(userId);

        }


        public void Delete(Guid userId)
        {
            shoppingCartRepository.Delete(userId);
        }

        public ShoppingCart Get(Guid userId)
        {
            return shoppingCartRepository.GetShoppingcart(userId);

        }

        public ShoppingCart AddProduct(Guid shoppingcartId, Guid productId)
        {
            try
            {
               
                var shoppingcart = shoppingCartRepository.GetShoppingcartById(shoppingcartId);
                shoppingcart.Products = _products;
                shoppingcart.Products.Add(productId);
                return shoppingcart;

            }
            catch (Exception w)
            {
                Console.WriteLine(w.Message);
            }

            return null;
        }

        public void DeleteProduct(Guid shoppingcartId, Guid productId)
        {
            try
            {
                var shop = shoppingCartRepository.GetShoppingcartById(shoppingcartId);
                shop.Products = _products;
                shop.Products.Remove(productId);
                
            }
            catch (InvalidIdException e)
            {

                Console.WriteLine(e.Message);
            }

        }

    }
}
