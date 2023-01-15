using NUnit.Framework;
using MovieSys.Services;
using MovieSys.Models;
using Microsoft.Extensions.Configuration;
using MovieSys.Contracts.Movie;

namespace MovieSys.Tests;

public class MovieServiceTest
{
    private readonly MovieService _movieService;
    private readonly IConfiguration _configuration;

    public MovieServiceTest()
    {
        _movieService = new MovieService();
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();
    }

    [Test]
    public void FindMovie_Works()
    {
        string id = "9a2adc60-a772-4495-8290-d39e653a0228";
        string unknownId = "00000000-0000-0000-0000-000000000000";

        MovieResponse? foundMovie = _movieService.FindMovie(id, _configuration["ConnectionStrings:Default"]);
        MovieResponse? unfoundMovie = _movieService.FindMovie(unknownId, _configuration["ConnectionStrings:Default"]);

        Assert.AreSame(unfoundMovie, null);
        if (foundMovie != null)
            Assert.That(foundMovie.Id, Is.EqualTo(foundMovie.Id));
    }

    [Test]
    public void CreateMovie_Works()
    {
        Movie movie = new(new Guid("00612540-24fc-4985-8fb2-98bedeefda01"), "Iron Man", "Jon Favreau", new DateOnly(2008, 5, 2));

        _movieService.CreateMovie(movie, _configuration["ConnectionStrings:Default"]);
        MovieResponse? foundMovie = _movieService.FindMovie(movie.Id.ToString(), _configuration["ConnectionStrings:Default"]);

        Assert.AreNotSame(foundMovie, null);
        if (foundMovie != null)
            Assert.That(foundMovie.Id, Is.EqualTo(movie.Id));
    }

    [Test]
    public void DeleteMovie_Works()
    {
        string id = "00612540-24fc-4985-8fb2-98bedeefda01";

        _movieService.DeleteMovie(id, _configuration["ConnectionStrings:Default"]);
        MovieResponse? foundMovie = _movieService.FindMovie(id, _configuration["ConnectionStrings:Default"]);

        Assert.AreSame(foundMovie, null);
    }
}