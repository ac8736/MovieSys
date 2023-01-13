using MovieSys.Controllers;
using MovieSys.Services;
using Microsoft.AspNetCore.Mvc;
using MovieSys.Contracts.Movie;
using MovieSys.Models;

namespace MovieSys.Contracts;

public class CastController : ApiController
{
    private readonly ICastService _cast;
    private readonly IMovieService _movie;
    public CastController(ICastService cast, IMovieService movie, IConfiguration configuration) : base(configuration)
    { _cast = cast; _movie = movie; }

    [HttpPost]
    public IActionResult CreateCast(CastRequest request)
    {
        var cast = new Casts(request.MovieID, request.Actor, request.Role);
        _cast.CreateCast(cast, _configuration["ConnectionStrings:Default"]);
        var response = new CastResponse(cast.Actor, cast.Role);
        return Ok(new Dictionary<string, string>() { { "status", "Successfuly added a cast member." } });
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieCast(string id)
    {
        if (_movie.FindMovie(id, _configuration["ConnectionStrings:Default"]) == null)
            return NotFound();
        var result = _cast.GetAllCast(id, _configuration["ConnectionStrings:Default"]);
        return Ok(new Dictionary<string, List<CastResponse>>() { { "cast", result } });
    }

    [HttpDelete]
    public IActionResult DeleteMovieCast(CastRequest request)
    {
        if (!_cast.FindCastMember(request, _configuration["ConnectionStrings:Default"]))
            return NotFound();
        _cast.DeleteCastMember(request, _configuration["ConnectionStrings:Default"]);
        return NoContent();
    }
}
