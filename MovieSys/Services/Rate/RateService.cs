using MovieSys.Contracts.Movie;
using MovieSys.Database;
using MovieSys.Models;
using MovieSys.Services.Rate;
using MySql.Data.MySqlClient;

public class RateService : IRateService
{
    public void CreateRating(Rating rate, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = String.Format("INSERT INTO rating VALUES('{0}', '{1}', '{2}', '{3}');", rate.MovieId, rate.UserId, rate.Rate, rate.Comment);
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        dbCon.Close();
    }

    public List<RatingResponse> GetAllRatingsByMovie(string? id, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        List<RatingResponse> result = new();
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = String.Format("SELECT user_id, rating, comment FROM rating WHERE movie_id='{0}'", id);
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new RatingResponse(new Guid(reader.GetString(0)), reader.GetInt32(1), reader.GetString(2)));
        }
        cmd.Dispose();
        dbCon.Close();
        return result;
    }

    public List<RatingResponse> GetAllRatingsByUser(string? id, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        List<RatingResponse> result = new();
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = String.Format("SELECT user_id, rating, comment FROM rating WHERE user_id='{0}'", id);
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new RatingResponse(new Guid(reader.GetString(0)), reader.GetInt32(1), reader.GetString(2)));
        }
        cmd.Dispose();
        dbCon.Close();
        return result;
    }

    public void DeleteRating(RatingRequest rating, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = String.Format("DELETE FROM rating WHERE movie_id='{0}' AND user_id='{1}'", rating.MovieId, rating.UserId);
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        cmd.Dispose();
        dbCon.Close();
    }

    public bool FindRating(RatingRequest rating, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = String.Format("SELECT * FROM rating WHERE movie_id='{0}' AND user_id='{1}'", rating.MovieId, rating.UserId);
        var cmd = new MySqlCommand(query, dbCon.Connection);
        bool result = cmd.ExecuteReader().HasRows;
        cmd.Dispose();
        dbCon.Close();
        return result;
    }
}