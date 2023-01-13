using MovieSys.Models;
using MovieSys.Contracts.Movie;

namespace MovieSys.Services;

public interface IRateService
{
    public void CreateRating(Rating rate, string? connectionString);
    public List<RatingResponse> GetAllRatingsByMovie(string? id, string? connectionString);
    public List<RatingResponse> GetAllRatingsByUser(string? id, string? connectionString);
    public void DeleteRating(RatingRequest rating, string? connectionString);
    public bool FindRating(RatingRequest rating, string? connectionString);
}