using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;

namespace AppProva.Repository
{
    public interface IProductRepository
    {
        void Delete(Guid id);
        Product Update(Guid productId);
        Product GetProduct(Guid id);
        Product Insert(Product product);
        IEnumerable<Product> GetAll();
       
    }
}
