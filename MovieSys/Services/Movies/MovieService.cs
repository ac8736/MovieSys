using MovieSys.Contracts.Movie;
using MovieSys.Models;
using MovieSys.Database;
using MySql.Data.MySqlClient;

namespace MovieSys.Services;

public class MovieService : IMovieService
{
    public void CreateMovie(Movie movie, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"INSERT INTO movie VALUES('{movie.Id}','{movie.Name}','{movie.Director}','{movie.Release.Year + "-" + movie.Release.Month + "-" + movie.Release.Day}')";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        dbCon.Close();
    }

    public MovieResponse? FindMovie(string id, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"SELECT * FROM movie WHERE id='{id}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
            return new MovieResponse(new Guid(reader.GetString(0)),
                                     reader.GetString(1),
                                     reader.GetString(2),
                                     new DateOnly(Int32.Parse(reader.GetString(3).Substring(6, 4)),
                                                  Int32.Parse(reader.GetString(3).Substring(0, 2)),
                                                  Int32.Parse(reader.GetString(3).Substring(3, 2))));
        cmd.Dispose();
        dbCon.Close();
        return null;
    }

    public void DeleteMovie(string id, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"DELETE FROM movie WHERE id='{id}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        cmd.Dispose();
        dbCon.Close();
    }
}