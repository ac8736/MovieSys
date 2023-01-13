using MovieSys.Services;
using Microsoft.AspNetCore.Mvc;
using MovieSys.Contracts.Movie;
using MovieSys.Models;

namespace MovieSys.Controllers;

public class RateController : ApiController
{
    private readonly IRateService _rate;
    public RateController(IRateService rate, IConfiguration configuration) : base(configuration)
        => _rate = rate;

    [HttpPost]
    public IActionResult CreateRating(RatingRequest request)
    {
        if (_rate.FindRating(request, _configuration["ConnectionStrings:Default"]))
            return BadRequest(new Dictionary<string, string>() { { "status", "Rating already created." } });
        var rate = new Rating(request.MovieId, request.UserId, request.Rating, request.Comment);
        _rate.CreateRating(rate, _configuration["ConnectionStrings:Default"]);
        var response = new RatingResponse(rate.UserId, rate.Rate, rate.Comment);
        return Ok(new Dictionary<string, string>() { { "status", "Rating successfully created." } });
    }

    [HttpGet("movie/{id}")]
    public IActionResult GetAllMovieRating(string id)
    {
        List<RatingResponse> ratings = _rate.GetAllRatingsByMovie(id, _configuration["ConnectionStrings:Default"]);
        if (ratings.Count == 0)
            return NotFound("No ratings for this movie.");
        return Ok(new Dictionary<string, List<RatingResponse>>() { { "ratings", ratings } });
    }

    [HttpGet("user/{id}")]
    public IActionResult GetAllUserRating(string id)
    {
        List<RatingResponse> ratings = _rate.GetAllRatingsByUser(id, _configuration["ConnectionStrings:Default"]);
        if (ratings.Count == 0)
            return NotFound("No ratings for this movie.");
        return Ok(new Dictionary<string, List<RatingResponse>>() { { "ratings", ratings } });
    }

    [HttpDelete]
    public IActionResult DeleteRating(RatingRequest request)
    {
        if (!_rate.FindRating(request, _configuration["ConnectionStrings:Default"]))
            return NotFound();
        _rate.DeleteRating(request, _configuration["ConnectionStrings:Default"]);
        return NoContent();
    }
}