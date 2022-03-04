using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;
using AppProva.Services;
using AppProva.Repository.Impl;
using AppProva.Repository;

namespace AppProva.Imp
{
    public class ProductService : IProduct
    {
        public IProductRepository productRepository { get; }

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository; 
        }
        
        public void Delete(Guid id)
        {
            try
            {
                productRepository.Delete(id);
            }
            catch (InvalidIdException e)
            {
                Console.WriteLine(e.Message);
              
            }

        }

        public Product Update(Guid productId)
        {
            return productRepository.Update(productId);
        }

        public Product GetProduct(Guid id)
        {
           return productRepository.GetProduct(id); 
        }

        public Product Insert(Product product)
        {
            return productRepository.Insert(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

    }
}
