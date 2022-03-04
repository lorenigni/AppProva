using AppProva.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProva.Repository
{
    public interface IShoppinCartRepository
    {
            
        ShoppingCart Creat(Guid userId);
        void Delete(Guid userId);
        ShoppingCart GetShoppingcart(Guid userId);

        List<ShoppingCart> GetAll();

        ShoppingCart GetShoppingcartById(Guid shoppincgartId);
    }
}
