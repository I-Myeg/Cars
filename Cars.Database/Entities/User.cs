namespace Cars.Database.Entities;

public class User
{
    public int Id { get; set; } 
    public string Email { get; set; }
    private string _password;
    public string Password
    {
        get => _password;
        set => _password = BCrypt.Net.BCrypt.HashPassword(value);
    }
    public Role Role { get; set; }
}

