using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Services;
using AppProva.Entities;
using AppProva.Imp;
using AppProva.Repository.Impl;

namespace AppProva
{
    internal class Program
    {

        static void Main()
        {


            /////////////////////Trying User Operations
            ///
            //User user1 = new User("Lorenzo", "Benigni", "lorenzo.benigni@crif.com");
            //User user2 = new User("Mario", "Rossi", "mario.rossi@crif.com");
            //User user3 = new User("Tizio", "beddu", "tiziobeddu@gmail.com");
            //List<User> users = new List<User>() { user2 };
            //List<User> usersTwo = new List<User>() { user1, user2, user3 };


            //// Declare an interface instance.
            //IUser obj = new UserService();

            //// Call the member.
            //// creating Users.
            //obj.CreateUser(user1);


            //foreach (User user in users)
            //{
            //    Console.WriteLine(user.email);
            //}

            //Console.WriteLine("---------------------------------------------");

            ////deleting users                      
            //obj.DeleteUser(user3);

            //foreach(User user in users)
            //{
            //    Console.WriteLine(user.Name);
            //}

            ////updating users
            //Console.WriteLine("---------------------------------------------");

            //obj.UpdateUser(user1, "MArco","Marco@gmail.com");

            //Console.WriteLine("---------------------------------------------");

            //foreach (User user in usersTwo)
            //{
            //    Console.WriteLine(user.email);
            //}
            //Console.WriteLine("---------------------------------------------");


            ////////////////  product operation and order operation  // Ordinare per i costi

            //IProduct item = new ProductService();
            //Product product1 = new Product(550, "Computer");
            //Product product2 = new Product(160, "Headphones");
            //Product product3 = new Product(200, "Hard disk");
            //Product product4 = new Product(350, "Computer");
            //List<Product> products = new List<Product>() {product1, product2, product3, product4};
            //ShoppinCart shop = new ShoppinCart("Shopping chart", item.GetProducts(products));
            //IOrder ent = new OrderService();
            //ent.doOrder(shop);

            //Guid guid = Guid.NewGuid();
            //Guid guid1 = Guid.NewGuid();
            //Console.WriteLine(guid1);
            //Console.WriteLine(guid);
            //UserRepository userRepository = new UserRepository();
            //userRepository.GetUser(guid1);
            //User user = new User();
            //Console.WriteLine(user.Id);
            //User user1 = new User();
            //Console.WriteLine(user1.Id);
            //userRepository.id = guid1;
            //Console.WriteLine(guid1);

            ShoppingCart shoppingCart = new();
            DateTime date = DateTime.Now;
            Console.WriteLine(date);
           
        }
    }
}
    
