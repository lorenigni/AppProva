using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProva.Repository.Impl
{
    internal class InvalidIdException : Exception
    {
        public InvalidIdException() { }

        public InvalidIdException(Guid guid) 
            : base(String.Format("Invalid Id: {0}", guid)) 
        {

        }


    }
}
