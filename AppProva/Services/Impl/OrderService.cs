using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Services;
using AppProva.Entities;
using AppProva.Imp;
using AppProva.Services.Impl;

namespace AppProva
{
    internal class OrderService : IOrder
    {
        public void doOrder(ShoppingCart shopping)
        { }
        //{
        //    foreach (Product p in shopping.Products)
        //    {
        //        Console.WriteLine($"{p.Description} : {p.Cost} $, total amount {shopping.Count} $");
        //    }
        //}
    }
}
