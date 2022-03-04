using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;
using AppProva.Services.Impl;

namespace AppProva.Services
{
    internal interface IOrder
    {
        void doOrder(ShoppingCart shopping);
    }
}
