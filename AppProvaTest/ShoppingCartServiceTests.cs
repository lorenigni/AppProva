using AppProva.Entities;
using AppProva.Repository;
using AppProva.Repository.Impl;
using AppProva.Services.Impl;
using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppProvaTest
{
    public class ShoppingCartServiceTests
    {
        public Guid _idGuid = Guid.NewGuid();

        
        
        [Fact]
        public void Insert_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())  // with GetLoose() vediamo se un metodo è chiamato, con GetStrict() se il metodo è chiamato nessun altro metodo può essere chiamato 
            {
                ShoppingCart s = new ShoppingCart() { UserId = _idGuid };

                mock.Mock<IShoppinCartRepository>()          // set up mockVariable (interface call), framework for creating fake items; this version will be passed instead of the real version
                .Setup(x => x.Creat(s.UserId))                            //set on or more methods
                .Returns(GetTheShoppingCart());                    // I mocked the Insert(user) we turn back the user created by the GetUser()

                var cls = mock.Create<ShoppingCartService>();   // we want to use it; cls is a class uses the mock to create the UserService; it runs out of mock, but when it asks for IUserRepository data access it gives the mock 
                var expected = GetTheShoppingCart();               //  
                var actual = cls.Creat(s.UserId);                      // here we use it

                Assert.Equal(expected.UserId, actual.UserId);

                mock.Mock<IShoppinCartRepository>()
                    .Verify(x => x.Creat(s.UserId), Times.Once());

            }

        }

        public ShoppingCart GetTheShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart() { Id = _idGuid };
            
            return cart;
                
        }





        [Fact]
        public void Delete_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())  // with GetLoose() vediamo se un metodo è chiamato, con GetStrict() se il metodo è chiamato nessun altro metodo può essere chiamato 
            {
                ShoppingCart s = new ShoppingCart() { Id = _idGuid };
                
                mock.Mock<IShoppinCartRepository>()          // set up mockVariable (interface call), framework for creating fake items; this version will be passed instead of the real version
                .Setup(x => x.Delete(_idGuid));                            //set on or more methods
                                                                           // I mocked the Insert(user) we turn back the user created by the GetUser()

                var cls = mock.Create<ShoppingCartService>();
                cls.Delete(_idGuid);
                mock.Mock<IShoppinCartRepository>()
                    .Verify(x => x.Delete(_idGuid), Times.Exactly(1));                   // here we use it


            }

        }




        [Fact]
        public void get_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose()) 
            {
                ShoppingCart s = new ShoppingCart() { UserId = _idGuid};
                
                mock.Mock<IShoppinCartRepository>()
                    .Setup(x=>x.GetShoppingcart(s.UserId))
                    .Returns(GetTheSho(_idGuid));

                var cls = mock.Create<ShoppingCartService>();
                var expected = GetTheSho(s.UserId);
                var actual = cls.Get(s.UserId);

                Assert.Equal(actual.Id, expected.Id);

                mock.Mock<IShoppinCartRepository>()
                    .Verify(x=>x.GetShoppingcart(s.UserId), Times.Exactly(1));   
            }
        }

        public ShoppingCart GetTheSho(Guid id)
        {
            return new ShoppingCart() { Id = _idGuid};
        }




        //[Fact]
        //public void AddProduct_ShouldWork()
        //{
        //    ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
        //    List<ShoppingCart> shoppingcarts = new List<ShoppingCart>() { s };
        //    ShoppingCartRepository shopRepo = new ShoppingCartRepository(shoppingcarts);
        //    ShoppingCartService shopService = new ShoppingCartService(shopRepo);
        //    shopService.AddProduct(s.Id, _idGuid);
        //    Assert.True(s.Products.Count > 0);

        //}


        //[Fact]
        //public void RemoveProduct_ShouldWork()
        //{
        //    ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
        //    List<ShoppingCart> shoppingcarts = new List<ShoppingCart>() { s };
        //    ShoppingCartRepository shopRepo = new ShoppingCartRepository(shoppingcarts);
        //    ShoppingCartService shopService = new ShoppingCartService(shopRepo);
        //    shopService.AddProduct(s.Id, _idGuid);
        //    shopService.DeleteProduct(s.Id, _idGuid);
        //    Assert.True(s.Products.Count == 0);

        //}

    }
}
