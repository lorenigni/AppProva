using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;
using Microsoft.Extensions.Logging;

namespace AppProva.Repository.Impl
{
    public class UserRepository : IUserRepository
    {

        public List<User> _listUsers;
        public ILogger<UserRepository> _logger;


        public UserRepository(ILogger<UserRepository> logger)
        {
            _listUsers = new List<User>();
            this._logger = logger;
        }
      

        
        public User Insert(User user)
        {

            int count = 0;
            for (int i = 0; i < _listUsers.Count; i++)
            {
                if (_listUsers[i].Id == user.Id)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                _listUsers.Add(user);
                return user;
            }
            else _logger.LogWarning("A user with that id already exists");
            return null;
        }



        public User GetUser(Guid id)
        {

            try
            {
                checkId(id);
            }
            catch (InvalidIdException e)
            {
                _logger.LogWarning(e.Message);
            }

            for (int i = 0; i < _listUsers.Count; i++)
            {
                if (_listUsers[i].Id == id)
                {
                    return _listUsers[i];
                }
            }
            return null;

        }


        public IEnumerable<User> GetAll()
        {
            _logger.LogInformation("Returning all users");
            return _listUsers;
        }



        public void Delete(Guid id)
        {
            try
            {
                checkId(id);
            }
            catch (InvalidIdException)
            {
                _logger.LogWarning($"There are no users with that id: {id}");
            }
            if (_listUsers.Count > 0)
            {
                _listUsers = _listUsers.Where(User => User.Id != id).ToList();

            }
        }


        public User Update(Guid id)
        {
            try
            {
                checkId(id);
            }
            catch (InvalidIdException)
            {
                _logger.LogWarning($"There are no users with that id: {id}");

            }
            if (_listUsers.Count != 0)
            {
                foreach (User u in _listUsers)
                {

                    if (u.Id == id)
                    {
                        string newEmail = "newemail@gmail.com";
                        u.Email = newEmail;
                        return u;

                    }

                }

            }
            return null;

        }
        public void checkId(Guid id)
        {
            var count = 0;
            for (int i = 0; i < _listUsers.Count; i++)
            {
                if (_listUsers[i].Id == id)
                {
                    count++;

                }
            }
            if (count == 0) { throw new InvalidIdException(); }
        }
    }
}







