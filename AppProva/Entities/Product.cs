using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppProva.Entities
{
    public class Product
    {
       
        public Guid Id { get; set; } 
        public int Cost { get; set; }
        public string Description { get; set; }

    }
}
