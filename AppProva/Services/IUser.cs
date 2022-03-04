using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;


namespace AppProva.Services
{
    public interface IUser
    {

        User Insert(User user);
        User Update(Guid id);
        void Delete(Guid id);
        User GetUser(Guid id);
        IEnumerable<User> GetAll();




    }
}
