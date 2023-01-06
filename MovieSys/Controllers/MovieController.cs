using Microsoft.AspNetCore.Mvc;
using MovieSys.Contracts.Movie;
using MovieSys.Models;
using MovieSys.Services.Movies;

namespace MovieSys.Controllers;

public class MovieController : ApiController
{
    private readonly IMovieService _movie;

    public MovieController(IMovieService movie, IConfiguration configuration) : base(configuration)
        => _movie = movie;

    [HttpPost]
    public IActionResult CreateMovie(MovieRequest request)
    {
        var movie = new Movie(Guid.NewGuid(), request.Name, request.Director, request.Release);
        _movie.CreateMovie(movie, _configuration["ConnectionStrings:Default"]);
        var response = new MovieResponse(movie.Id, movie.Name, movie.Director, movie.Release);
        return CreatedAtAction(actionName: nameof(FindMovie), routeValues: new { id = movie.Id }, value: response);
    }

    [HttpGet("{id}")]
    public IActionResult FindMovie(string id)
    {
        var movie = _movie.FindMovie(id, _configuration["ConnectionStrings:Default"]);
        if (movie == null)
            return NotFound();
        return Ok(movie);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(string id)
    {
        _movie.DeleteMovie(id, _configuration["ConnectionStrings:Default"]);
        return NoContent();
    }
}
