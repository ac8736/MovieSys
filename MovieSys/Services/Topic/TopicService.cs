using MovieSys.Contracts.Movie;
using MovieSys.Database;
using MovieSys.Models;
using MySql.Data.MySqlClient;

namespace MovieSys.Services.Topics;

public class TopicService : ITopicService
{
    public void CreateTopic(Topic topic, string? connectionString)
    {
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"INSERT INTO topic VALUES('{topic.MovieId}', '{topic.TopicName}')";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        dbCon.Close();
    }

    public List<TopicResponse> GetAllTopic(string id, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        List<TopicResponse> result = new();
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"SELECT topic FROM topic WHERE movie_id='{id}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
            result.Add(new TopicResponse(reader.GetString(0)));
        cmd.Dispose();
        dbCon.Close();
        return result;
    }

    public void DeleteTopic(TopicRequest request, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"DELETE FROM topic WHERE movie_id='{request.MovieId}' AND topic='{request.Topic}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        cmd.Dispose();
        dbCon.Close();
    }

    public bool FindTopic(TopicRequest request, string? connectionString)
    {
        if (connectionString == null)
            throw new Exception("Null Connection String.");
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"SELECT * FROM topic WHERE movie_id='{request.MovieId}' AND topic='{request.Topic}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        bool result = cmd.ExecuteReader().HasRows;
        cmd.Dispose();
        dbCon.Close();
        return result;
    }
}