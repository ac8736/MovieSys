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
        string query = String.Format("INSERT INTO movie_cast VALUES('{0}', '{1}', '{2}');", cast.MovieId, cast.Actor, cast.Role);
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
        string query = String.Format("SELECT actor_name, role FROM movie_cast WHERE movie_id='{0}'", id);
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new CastResponse(reader.GetString(0), reader.GetString(1)));
        }
        cmd.Dispose();
        dbCon.Close();
        return result;
    }

    public void DeleteCastMember(CastRequest request, string? connectionString)
    {
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = String.Format("DELETE from movie_cast WHERE movie_id='{0}' AND actor_name='{1}' AND role='{2}'",
                                     request.MovieID, request.Actor, request.Role);
        var cmd = new MySqlCommand(query, dbCon.Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        dbCon.Close();
    }

    public bool FindCastMember(CastRequest request, string? connectionString)
    {
        var dbCon = new DBConnection(connectionString);
        dbCon.Connect();
        string query = String.Format("SELECT * FROM movie_cast WHERE movie_id='{0}' AND actor_name='{1}' AND role='{2}'",
                                     request.MovieID, request.Actor, request.Role);
        var cmd = new MySqlCommand(query, dbCon.Connection);
        bool result = cmd.ExecuteReader().HasRows;
        cmd.Dispose();
        dbCon.Close();
        return result;
    }
}