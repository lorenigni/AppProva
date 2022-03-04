using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Repository.Impl;
using Xunit;
using  AppProva.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace AppProvaTest
{
    public class UserRepositoryTest
    {
        private Mock<ILogger<UserRepository>> _logger = new();

       

        //      GETUSER

        [Fact]
        public void GetUser_ShouldWork()
        {
            User user = new User() { Id = Guid.NewGuid() };
            UserRepository u = new UserRepository(_logger.Object);
            u.Insert(user);
            Assert.NotNull(u.GetUser(user.Id));

        }




        [Fact]
        public void GetUser_ShouldFail()
        {
            User user = new User() { Id = Guid.NewGuid() };
            UserRepository u = new UserRepository(_logger.Object);
            u.Insert(user);
            Assert.Null(u.GetUser(Guid.NewGuid()));
        }


        //       INSERT

        [Fact]
        public void InsertUser_ShouldWork()
        {
            User user = new User() { Id = Guid.NewGuid()};
            UserRepository u = new UserRepository(_logger.Object);
            u.Insert(user);
            Assert.True(u._listUsers.Count == 1);
            Assert.Contains<User>(user, u._listUsers);

        }




        //        DELETE

        [Fact]
        public void DeleteUser_ShouldWork()
        {
            User user = new User() { Id = Guid.NewGuid() };
            UserRepository u = new UserRepository(_logger.Object);
            u.Insert(user);
            u.Delete(user.Id);
            Assert.True(u._listUsers.Count == 0);


        }



        //         UPDATE

        [Fact]
        public void Updateuser_ShouldUpdate()
        {
            User user = new User() { Id = Guid.NewGuid() };
            UserRepository u = new UserRepository(_logger.Object);
            u.Insert(user);
            u.Update(user.Id);
            Assert.True(user.Email == "newemail@gmail.com");


        }



        //         GETALL

        [Fact]
        public void GetAllUsers_ShouldWork()
        {
            User user = new User() { Id = Guid.NewGuid() };
            UserRepository u = new UserRepository( _logger.Object);
            u.Insert(user);
            Assert.Contains<User>(user, u.GetAll());
        }

    }
}




