using AppProva.Repository;
using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AppProva.Entities;
using AppProva.Repository.Impl;
using AppProva.Services;
using AppProva.Imp; 


namespace AppProvaTest
{
    public class ProductServiceTests
    {
        [Fact]
        public void Delete_ShouldWork()
        {
            Guid guid = Guid.NewGuid(); 
            var mock = AutoMock.GetLoose();
            mock.Mock<IProductRepository>()
                .Setup(x => x.Delete(guid));
            
            var cls = mock.Create<ProductService>();
            cls.Delete(guid);
            mock.Mock<IProductRepository>()
                .Verify(x => x.Delete(guid), Times.Once());
            
        }


        [Fact]
        public void UpdateUser_Shouldupdate()
        {
            Product product = new Product() { Cost = 1, Description = "pizza" };
            var mock = AutoMock.GetLoose();
            mock.Mock<IProductRepository>()
                .Setup(x => x.Update(product.Id))
                .Returns(GetTheProduct());
            
            var cls = mock.Create<ProductService>();
            var expected = GetTheProduct();
            var actual = cls.Update(product.Id);
            Assert.True(expected.Cost == actual.Cost);
            Assert.True(expected.Id == actual.Id);
            Assert.True(expected.Description == actual.Description);

            mock.Mock<IProductRepository>()
                .Verify(x=>x.Update(product.Id), Times.Once());
        }

        public Product GetTheProduct()
        {
            Product p = new Product() { Cost = 1 , Description = "pizza"};
            return p;
        }


        [Fact]
        public void GetProduct_ShouldWork()
        {
            Guid guid = Guid.NewGuid();
            var mock = AutoMock.GetLoose();
            mock.Mock<IProductRepository>()
                .Setup(x => x.GetProduct(guid))
                .Returns(GetTheProduct());

            var cls = mock.Create<ProductService>();
            var expected = GetTheProduct();
            var actual = cls.GetProduct(guid);

            Assert.True(expected.Cost == actual.Cost);

            mock.Mock<IProductRepository>()
                .Verify(x=>x.GetProduct(guid), Times.Once());



        }

        [Fact]
        public void GetAll_ShoulWork()
        {
            var mock = AutoMock.GetLoose();
            mock.Mock<IProductRepository>()
                .Setup(x => x.GetAll())
                .Returns(GetAllTheProducts());

            var cls = mock.Create<ProductService>();
            var expected = GetAllTheProducts();
            var actual = cls.GetAll();
            
            List<Product> actualList = actual.ToList();
            List<Product> expecteList = expected.ToList();

            Assert.True(actualList.Count == expecteList.Count);
            Assert.True(actualList[0].Description == "lollypop");
            Assert.True(expecteList[0].Description == "lollypop");


            mock.Mock<IProductRepository>()
                .Verify(x=> x.GetAll(), Times.Once());



        }

        public IEnumerable<Product> GetAllTheProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Cost = 1 ,Description = "lollypop"},
                new Product() { Cost = 1 ,Description = "pizza" } 
            };   
            return products;
        }


        [Fact]
        public void InsertProduct_ShouldWork()
        {
            var mock = AutoMock.GetLoose();
            Product product = new Product() { Cost = 1};
            mock.Mock<IProductRepository>()
                .Setup(x => x.Insert(product))
                .Returns(GetTheProduct());

            var cls = mock.Create<ProductService>();
            var expected = GetTheProduct();
            var actual = cls.Insert(product);

            Assert.True(expected.Cost == actual.Cost);

            mock.Mock<IProductRepository>()
                .Verify(x => x.Insert(product), Times.Once());



        }

    }
}
