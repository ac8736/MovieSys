using MovieSys.Models;
using MovieSys.Database;
using MySql.Data.MySqlClient;
using MovieSys.Contracts.Movie;
using BC = BCrypt.Net.BCrypt;

namespace MovieSys.Services.Users;

public class UserService : IUserService
{
    public void CreateUser(User user, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string password = BC.HashPassword(user.Password);
        string query = $"INSERT INTO `user` VALUES('{user.Id}', '{user.Email}', '{user.Username}', '{password}')";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        dbCon.Close();
    }

    public UserResponse? FindUser(string id, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"SELECT * FROM `user` WHERE id='{id}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
            return new UserResponse(new Guid(reader.GetString(0)), reader.GetString(1), reader.GetString(2));
        cmd.Dispose();
        dbCon.Close();
        return null;
    }

    public void DeleteUser(string id, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"DELETE FROM `user` WHERE id='{id}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        cmd.Dispose();
        dbCon.Close();
    }
}