using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;

namespace AppProva.Repository
{
    public interface IUserRepository
    {
        User Insert(User user); // prendere oggetto usere aggiungere alla lista
        User Update( Guid id); // vedere se lo user esiste (ricerca per id), se non c'è tirare l'eccezione (custom exc), se lo trova aggiornare (solo email)
        void Delete(Guid id);  //cercare per id, se c'è cancellarlo
        User GetUser(Guid id); //cerca per id, tira ec
        IEnumerable<User> GetAll(); //tornare tutti gli user

    }
}
