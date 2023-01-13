using MySql.Data.MySqlClient;
using MovieSys.Database;
using MovieSys.Contracts.Movie;
using MovieSys.Models;

namespace MovieSys.Services.Cast;

public class CastService : ICastService
{
    public void CreateCast(Casts cast, string? connectionString)
    {
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"INSERT INTO movie_cast VALUES('{cast.MovieId}', '{cast.Actor}', '{cast.Role}')";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        dbCon.Close();
        cmd.Dispose();
    }

    public List<CastResponse> GetAllCast(string? id, string? connectionString)
    {
        List<CastResponse> result = new();
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"SELECT actor_name, role FROM movie_cast WHERE movie_id='{id}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
            result.Add(new CastResponse(reader.GetString(0), reader.GetString(1)));
        cmd.Dispose();
        dbCon.Close();
        return result;
    }

    public void DeleteCastMember(CastRequest request, string? connectionString)
    {
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"DELETE FROM movie_cast WHERE movie_id='{request.MovieID}' AND actor_name='{request.Actor}' AND role='{request.Role}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        dbCon.Close();
    }

    public bool FindCastMember(CastRequest request, string? connectionString)
    {
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = $"SELECT * FROM movie_cast WHERE movie_id='{request.MovieID}' AND actor_name='{request.Actor}' AND role='{request.Role}'";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        bool result = cmd.ExecuteReader().HasRows;
        cmd.Dispose();
        dbCon.Close();
        return result;
    }
}