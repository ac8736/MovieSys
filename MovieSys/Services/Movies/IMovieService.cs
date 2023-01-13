using MovieSys.Models;
using MovieSys.Contracts.Movie;

namespace MovieSys.Services;

public interface IMovieService
{
    public void CreateMovie(Movie movie, string? connectionString);

    public MovieResponse? FindMovie(string id, string? connectionString);
    public void DeleteMovie(string id, string? connectionString);
}