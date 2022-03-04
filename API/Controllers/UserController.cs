using AppProva.Entities;
using AppProva.Repository;
using Microsoft.AspNetCore.Mvc;
using AppProva.Services;
using Microsoft.Extensions.Logging;

namespace AppProva.Controllers
{
    
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUser _iuser;
        public ILogger _logger;


        public UserController(IUser iuser, ILoggerFactory loggerFactory)
        {
            _iuser = iuser;
            _logger = loggerFactory.CreateLogger("UserControllerCategory");

        }


        [HttpGet("{userId}")]  
        public ActionResult<User> GetUser(Guid userId)
        {
           
            var u = _iuser.GetUser(userId);
            if (u == null)
            {
                _logger.LogWarning($"User with Id {userId} not found");
                return NotFound();
            }

            return u;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            _logger.LogInformation("Getting all the users!");
            var users = _iuser.GetAll();
            return users;
        }


        [HttpDelete("{userId}")] 
        public void Delete(Guid userId)
        {
            _iuser.Delete(userId);
            
        }


        [HttpPut("{userId}")]
        public User Update(Guid userId)
        {
            //_logger.LogTrace($"This kind of method returns an updated user with email = {user.Email}"); -> nella repos
            _logger.LogInformation("The email has been modified");
            return _iuser.Update(userId);

        }


        [HttpPost] 
        public User Insert(User user)
        {
            _logger.LogInformation("User created on {PlaceHolderName: MM dd, yyyy}", DateTimeOffset.UtcNow);
            return _iuser.Insert(user);
        }


        
    }
}
