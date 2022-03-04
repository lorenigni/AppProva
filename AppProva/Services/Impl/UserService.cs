using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Services;
using AppProva.Entities;
using AppProva.Imp;
using AppProva.Repository.Impl;
using AppProva.Repository;
using Microsoft.Extensions.Logging;

namespace AppProva.Imp
{
    public class UserService : IUser
    {
        public IUserRepository userRepository { get; }
        public ILogger<UserService> _logger;


        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            this.userRepository = userRepository;
            this._logger = logger;   
            
        }


        public  User Insert(User user)
            
        {
            _logger.LogInformation("Creating the user");
             
            return userRepository.Insert(user);
            
        }


        public void Delete(Guid id) { 
            userRepository.Delete(id);
            
        }

        
        public User Update(Guid id)
        {   
           return  userRepository.Update(id);

        }

        public User GetUser(Guid id)
        {
             return userRepository.GetUser(id);
        }


        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }
    } 
}
