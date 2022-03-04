using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;
using AppProva.Repository;
using Microsoft.Extensions.Logging;

namespace AppProva.Repository.Impl
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> _products;
        public ILogger<ProductRepository> _logger;

        public ProductRepository(ILogger<ProductRepository> logger)
        {
            this._products = new List<Product>();
            this._logger = logger;
        }


        public void Delete(Guid id)
        {
            try
            {
                checkId(id);
            }
            catch (InvalidIdException e)
            {
                
                _logger.LogWarning("There are no products with that id");
            }

            _products = _products.Where(Product => Product.Id != id).ToList();


        }

        public Product GetProduct(Guid id)
        {
            try
            {
                checkId(id);
            }
            catch (InvalidIdException e)
            {
                _logger.LogWarning(e.Message);
            }

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Id == id)
                {
                    return _products[i];
                }
            }
            return null;
        }

        public Product Insert(Product product)
        {
            int count = 0;
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Id == product.Id )
                {
                    count++;
                }
            }
            if (count == 0)
            {
                _products.Add(product);
                return product;
            }
            else _logger.LogWarning("A product with that id alrrady exists");
            return null;
        }

        public Product Update(Guid productId)
        {
            try
            {
                checkId(productId);
            }
            catch (InvalidIdException e)
            {
                _logger.LogWarning(e.Message);
            }

            foreach (Product p in _products)
            {
                if (p.Id == productId)
                {
                    int costNew = 10;
                    p.Cost = costNew;
                    return p;
                }

            }
            return null;
        }

            public IEnumerable<Product> GetAll()
            {
                
                return _products;
            }


            public void checkId(Guid id)
            {
                var count = 0;
                for (int i = 0; i < _products.Count; i++)
                {
                    if (_products[i].Id == id)
                    {
                        count++;

                    }
                }
                if (count == 0) { throw new InvalidIdException(); }
            }

        }
    }







