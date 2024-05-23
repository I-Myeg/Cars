using Cars.Database.Entities;

namespace Cars.Domain.Models;

public class UserModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}