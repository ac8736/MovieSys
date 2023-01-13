using MovieSys.Contracts.Movie;
using MovieSys.Database;
using MovieSys.Models;
using MySql.Data.MySqlClient;

namespace MovieSys.Services;

public class WatchService : IWatchService
{
    public void SetWatched(Watch watch, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"INSERT INTO watched VALUES('{watch.MovieId}', '{watch.UserId}')";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        dbCon.Close();
    }

    public bool AlreadyWatched(Watch watch, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"SELECT * FROM watched WHERE movie_id='{watch.MovieId}' AND user_id='{watch.UserId}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        bool result = cmd.ExecuteReader().HasRows;
        cmd.Dispose();
        dbCon.Close();
        return result;
    }

    public List<WatchResponse> GetAllMoviesWatchedByUser(string? id, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        List<WatchResponse> result = new();
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"SELECT * FROM watched WHERE user_id='{id}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        return result;
    }

    public void DeleteWatched(Watch watch, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"DELETE FROM watched WHERE movie_id='{watch.MovieId}' AND user_id='{watch.UserId}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        dbCon.Close();
    }
}