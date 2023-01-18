using NUnit.Framework;
using MovieSys.Services;
using MovieSys.Models;
using Microsoft.Extensions.Configuration;
using MovieSys.Contracts.Movie;

namespace MovieSys.Tests;

public class RateServiceTest
{
    private readonly RateService _rateService;
    private readonly IConfiguration _configuration;

    public RateServiceTest()
    {
        _rateService = new RateService();
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();
    }

    [Test, Order(1)]
    public void Create_FindRating_Works()
    {
        RatingRequest request = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), new Guid("682671f8-00f1-4155-8416-8b4f3ff97126"), 5, "Good movie");
        Rating rate = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), new Guid("682671f8-00f1-4155-8416-8b4f3ff97126"), 5, "Good movie");

        _rateService.CreateRating(rate, _configuration["ConnectionStrings:Default"]);
        bool found = _rateService.FindRating(request, _configuration["ConnectionStrings:Default"]);

        Assert.IsTrue(found);
    }

    [Test, Order(2)]
    public void GetAllRatingsByMovie_Works()
    {
        string id = "9a2adc60-a772-4495-8290-d39e653a0228";
        List<RatingResponse> listOfRating = new() { new RatingResponse(new Guid("682671f8-00f1-4155-8416-8b4f3ff97126"), 5, "Good movie") };

        List<RatingResponse> response = _rateService.GetAllRatingsByMovie(id, _configuration["ConnectionStrings:Default"]);

        Assert.That(listOfRating, Is.EqualTo(response));
    }

    [Test, Order(3)]
    public void GetAllRatingsByUser_Works()
    {
        string id = "682671f8-00f1-4155-8416-8b4f3ff97126";
        List<RatingResponse> listOfRating = new() { new RatingResponse(new Guid("682671f8-00f1-4155-8416-8b4f3ff97126"), 5, "Good movie") };

        List<RatingResponse> response = _rateService.GetAllRatingsByUser(id, _configuration["ConnectionStrings:Default"]);

        Assert.That(listOfRating, Is.EqualTo(response));
    }

    [Test, Order(4)]
    public void DeleteRating_Works()
    {
        RatingRequest request = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), new Guid("682671f8-00f1-4155-8416-8b4f3ff97126"), 5, "Good movie");

        _rateService.DeleteRating(request, _configuration["ConnectionStrings:Default"]);
        bool found = _rateService.FindRating(request, _configuration["ConnectionStrings:Default"]);

        Assert.IsFalse(found);
    }
}