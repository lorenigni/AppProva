using AppProva.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProva.Services
{
    public interface IShoppingCart
    {
        
        ShoppingCart Creat(Guid userId); // controllo finale se user Id esiste nella userRepository
        void Delete(Guid userId);
        ShoppingCart Get(Guid userId);
        ShoppingCart AddProduct(Guid shoppingcartId, Guid productId); // il carrello già esiste, se non esiste mina
        void DeleteProduct(Guid shoppincartId, Guid productId);
        List<ShoppingCart> GetAll();
    }
}
