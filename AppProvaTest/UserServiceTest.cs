using AppProva.Entities;
using AppProva.Imp;
using AppProva.Repository;
using AppProva.Repository.Impl;
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
    public class UserServiceTest
    {



        //              INSERT USER
       [Fact]
       public void InsertUser_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())  // with GetLoose() vediamo se un metodo è chiamato, con GetStrict() se il metodo è chiamato nessun altro metodo può essere chiamato 
            {
                User user = new User();

                mock.Mock<IUserRepository>()          // set up mockVariable (interface call), framework for creating fake items; this version will be passed instead of the real version
                .Setup(x => x.Insert(user))            //set on or more methods
                .Returns(GetUser());                    // I mocked the Insert(user) we turn back the user created by the GetUser()

                var cls = mock.Create<UserService>();   // we want to use it; cls is a class uses the mock to create the UserService; it runs out of mock, but when it asks for IUserRepository data access it gives the mock 
                var expected = GetUser();               //  
                var actual = cls.Insert(user);          // here we use it
                Assert.True(actual != null);
                Assert.Equal(expected.Name, actual.Name);
                Assert.Equal(expected.Surname, actual.Surname);
                
                Assert.Equal(expected.Id, actual.Id);  
                
                mock.Mock<IUserRepository>()
                    .Verify(x => x.Insert(user), Times.Once());

            }

        } 
        private User GetUser()
        {
            User user = new User() { Email = "newemail@gmail.com" };
            
            return user;
        }


        //              UPDATE USER

        // DOMANDA. MA SE L'OPERAZIONE CAMBIA L'EMAIL, PERCHé RIMANGONO COMUNQUE UGUALI
        
        [Fact]
        public void UpdateUser_ShouldWork()
        {
            using var mock = AutoMock.GetLoose();
           {
                User user = new User() { Name = "Marco", Surname = "NoLai", Email = "jshb"};

                mock.Mock<IUserRepository>()
                    .Setup(x => x.Update(user.Id))
                    .Returns(GetUser());

                var cls = mock.Create<UserService>();
                var expected = GetUser();
                var actual = cls.Update(user.Id);
                Assert.Equal(expected.Name, actual.Name);

                mock.Mock<IUserRepository>()
                    .Verify(x => x.Update(user.Id), Times.Once());
                mock.Mock<IUserRepository>()
                   .Verify(x=>x.Update(user.Id), Times.Exactly(1));


           }

        }

        //          GETALL USERS    
        // VA BENE TRASFORMARLA IN UNA LISTA

        [Fact]
        public void GetAllUsers_ShouldWork()
        
        
        {
            using var mock = AutoMock.GetLoose();
            {
                mock.Mock<IUserRepository>()
                    .Setup(x => x.GetAll())
                    .Returns(GetAllUsers());

                var cls = mock.Create<UserService>();
                var expected = GetAllUsers();
                var actual = cls.GetAll();
                List<User> actualList = actual.ToList();
                List<User> expectedList = expected.ToList();
                Assert.True(actualList.Count == expectedList.Count);

                mock.Mock<IUserRepository>()
                    .Verify(x=>x.GetAll(), Times.Once());

            }
        }


        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>()
            {
                new User() { Name = "Pino"},
                new User() { Name = "Ponio"},
                new User() { Name = "Pippo"}
            };
            return users;
        }



        //      DELETE USERS

        [Fact]
        public void DeleteUsers_ShouldWork()
        {
            var mock = AutoMock.GetLoose();
            {
                Guid guid = new Guid();

                mock.Mock<IUserRepository>()
                   .Setup(x => x.Delete(guid));

                var cls = mock.Create<UserService>();
                cls.Delete(guid);
                mock.Mock<IUserRepository>()
                    .Verify(x => x.Delete(guid), Times.Exactly(1));     // expect the method to be acted once
            }
        }

        private void DeleteUser()
        {

        }




        //      GETUSER

        [Fact]
        public void GetUser_ShouldWork()
        {
            var mock = AutoMock.GetLoose();
            {
                Guid guid = Guid.NewGuid(); 
                mock.Mock<IUserRepository>()
                    .Setup(x => x.GetUser(guid))
                    .Returns(GetUser());

                var cls = mock.Create<UserService>();
                var expected = GetUser();
                var actual = cls.GetUser(guid);
                Assert.True(actual.Name == expected.Name);
                Assert.True(actual.Surname == expected.Surname);
                mock.Mock<IUserRepository>()
                    .Verify(x => x.GetUser(guid), Times.Exactly(1));  // per vedere che sia applicato esattamente due volte bisogna frlo nel SERVICE

            }
           
        }
    }
}
