using MovieSys.Models;
using MovieSys.Contracts.Movie;

namespace MovieSys.Services;

public interface IUserService
{
    public void CreateUser(User user, string? connectionString);
    public UserResponse? FindUser(string id, string? connectionString);
    public void DeleteUser(string id, string? connectionString);
}