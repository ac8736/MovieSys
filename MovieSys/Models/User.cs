namespace MovieSys.Models;

public class User
{
    public Guid Id { get; }
    public string Email { get; }
    public string Username { get; }
    public string Password { get; }
    public User(
        Guid id,
        string email,
        string username,
        string password)
    {
        Id = id;
        Email = email;
        Username = username;
        Password = password;
    }
}