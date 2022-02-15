using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva;

namespace AppProva.Entities
{
    public  class ShoppingCart
    {
        public DateTime Date { get; set; }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public List<Guid> Products { get; set; }


        //public int Count
        //{
        //    get
        //    {
        //        int count = 0;

        //        Products = new List<Product>();
        //        try
        //        {
        //            foreach (var p in Products)
        //            {
        //                count = count + p.Cost;
        //            }
        //            return count;
        //        }
        //        catch (InvalidOperationException e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //        return 0;
        //    }
        //}


    }
}
