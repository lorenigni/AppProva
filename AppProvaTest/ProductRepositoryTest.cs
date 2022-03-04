using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AppProva.Entities;
using AppProva.Repository;
using AppProva.Repository.Impl;
using Microsoft.Extensions.Logging;
using Moq;

namespace AppProvaTest
{
    public class ProductRepositoryTest
    {

        private Mock<ILogger<ProductRepository>> _logger = new();

        [Fact]
        public void Delete_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            ProductRepository p = new ProductRepository(_logger.Object);
            p.Insert(product);
            p.Delete(product.Id);
            Assert.True(p._products.Count == 0);
        }



        [Fact]
        public void Update_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            ProductRepository p = new ProductRepository(_logger.Object);
            p.Insert(product);
            p.Update(product.Id);
            Assert.True(product.Cost == 10);


        }



        [Fact]
        public void Insert_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            ProductRepository p = new ProductRepository(_logger.Object);
            p.Insert(product);
            Assert.Contains<Product>(product, p._products);

        }


        [Fact]
        public void getAll_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            ProductRepository p = new ProductRepository(_logger.Object);
            p.Insert(product);
            Assert.Contains(product, (p.GetAll()));

        }

        [Fact]
        public void GetProduct_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            ProductRepository productRepository = new ProductRepository(_logger.Object);
            productRepository.Insert(product);  
            Assert.NotNull(productRepository.GetProduct(product.Id));

        }
    }
}
