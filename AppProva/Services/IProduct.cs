using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;

namespace AppProva.Services
{
    public interface IProduct
    {


        Product Insert(Product product);
        Product Update(Guid productId);
        void Delete(Guid id);
        Product GetProduct(Guid id);
        IEnumerable<Product> GetAll();

    }
}
