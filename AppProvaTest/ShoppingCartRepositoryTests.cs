using AppProva.Entities;
using AppProva.Repository;
using AppProva.Repository.Impl;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace AppProvaTest
{
    public class ShoppingCartRepositoryTests
    {

        private Mock<ILogger<ShoppingCartRepository>> _loggerMock = new();

        [Fact]
        public void Insert_ShouldWork()
        {
            ShoppingCart s = new ShoppingCart() { UserId = Guid.NewGuid() };
            List<ShoppingCart> shoppingcarts = new List<ShoppingCart>() {};
            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository(_loggerMock.Object);
            shoppingCartRepository.Creat(s.UserId);
            Assert.True(shoppingCartRepository._shoppincharts.Count > 0);
        }

        [Fact]
        public void Delete_ShouldWork()
        {
            ShoppingCart s = new ShoppingCart() { UserId = Guid.NewGuid() };
            ShoppingCartRepository shop = new ShoppingCartRepository(_loggerMock.Object);
            shop.Creat(s.UserId);   
            shop.Delete(s.UserId);
            Assert.True(shop._shoppincharts.Count == 0);

        }

        [Fact]
        public void Get_ShouldGet()
        {
            ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
            ShoppingCartRepository shop = new ShoppingCartRepository(_loggerMock.Object);
            shop.Creat(s.UserId);
            shop.GetShoppingcart(s.UserId);
            Assert.NotNull(shop.GetShoppingcart(s.UserId));

        }


        [Fact]
        public void GetShoppinCartById_ShouldWork()
        {
            ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
            ShoppingCartRepository shop = new ShoppingCartRepository(_loggerMock.Object);
            shop.Creat(s.UserId);
            Assert.NotNull(shop.GetShoppingcartById(shop._shoppincharts[0].Id));
        }


        [Fact]
        public void GetShoppinCartById_ShouldFail()
        {
            ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
            ShoppingCartRepository shop = new ShoppingCartRepository(_loggerMock.Object);
            //Assert.Throws<Exception>(() => shop.GetShoppingcartById(Guid.Empty));
            shop.Creat(s.UserId);
            Assert.Null(shop.GetShoppingcartById(Guid.Empty));

        }




    }
}
