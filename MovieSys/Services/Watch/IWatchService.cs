using MovieSys.Contracts.Movie;
using MovieSys.Models;

namespace MovieSys.Services;

public interface IWatchService
{
    public void SetWatched(Watch watch, string? connectionString);
    public bool AlreadyWatched(Watch watch, string? connectionString);
    public List<WatchResponse> GetAllMoviesWatchedByUser(string? id, string? connectionString);
    public void DeleteWatched(Watch watch, string? connectionString);
}