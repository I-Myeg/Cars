using Cars.Database.Entities;
using Cars.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Cars.Domain.Services
{
    public class UserService
    {
        private readonly List<User> _users;
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger)
        {
            _users = new List<User>();
            _logger = logger;
        }

        public void RegisterUser(UserModel userModel)
        {
            if (_users.Any(u => u.Email == userModel.Email))
            {
                _logger.LogWarning($"User with email {userModel.Email} already exists.");
                throw new System.Exception("User already exists.");
            }

            var user = new User
            {
                Email = userModel.Email,
                Password = userModel.Password, 
                Role = userModel.Role
            };

            _users.Add(user);
            _logger.LogInformation($"User with email {userModel.Email} registered successfully.");
        }

        public UserModel Authenticate(string email, string password)
        {
            var user = _users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                _logger.LogWarning($"Authentication failed for email {email}.");
                return null;
            }

            _logger.LogInformation($"User with email {email} authenticated successfully.");
            return new UserModel
            {
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
        }

        public UserModel GetUserByEmail(string email)
        {
            var user = _users.SingleOrDefault(u => u.Email == email);

            if (user == null)
            {
                _logger.LogWarning($"User with email {email} not found.");
                return null;
            }

            _logger.LogInformation($"User with email {email} found.");
            return new UserModel
            {
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
        }
    }
}
