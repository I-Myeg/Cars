using Cars.Database.Entities;

namespace Cars.Domain.Interfaces;

public interface IUserService
{
    Task<User> GetUserByEmail(string email);
    Task<bool> ValidateUser(string email, string password);
    Task<string> CreateUser(User user);
    Task<string> Login(string email, string password);
    string GenerateJwtToken(User user);
    
}