namespace Cars.Database.Entities;

public class User
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}

public class Role
{
    public string Name { get; set; }
    public Role(string name) => Name = name;
}