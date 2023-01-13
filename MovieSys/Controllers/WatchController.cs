using Microsoft.AspNetCore.Mvc;
using MovieSys.Contracts.Movie;
using MovieSys.Models;
using MovieSys.Services;

namespace MovieSys.Controllers;

public class WatchController : ApiController
{
    private readonly IWatchService _watch;

    public WatchController(IConfiguration configuration, IWatchService watch) : base(configuration)
        => _watch = watch;

    [HttpPost]
    public IActionResult SetWatch(WatchRequest request)
    {
        Watch watch = new(request.MovieId, request.UserId);
        if (_watch.AlreadyWatched(watch, _configuration["ConnectionStrings:Default"]))
            return BadRequest(new Dictionary<string, string>() { { "status", "Topic already created." } });
        _watch.SetWatched(watch, _configuration["ConnectionStrings:Default"]);
        return Ok();
    }

    [HttpGet("{user_id}")]
    public IActionResult GetMoviesWatchedByUser(string id)
    {
        var result = _watch.GetAllMoviesWatchedByUser(id, _configuration["ConnectionStrings:Default"]);
        if (result.Count == 0)
            return NotFound();
        return Ok(new Dictionary<string, List<WatchResponse>>() { { "movies", result } });
    }

    [HttpDelete]
    public IActionResult DeleteWatchedMovie(WatchRequest request)
    {
        Watch watch = new(request.MovieId, request.UserId);
        if (!_watch.AlreadyWatched(watch, _configuration["ConnectionStings:Default"]))
            return NotFound();
        _watch.DeleteWatched(watch, _configuration["ConnectionStrings:Default"]);
        return NoContent();
    }
}