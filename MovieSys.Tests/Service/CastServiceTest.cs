using NUnit.Framework;
using MovieSys.Services;
using MovieSys.Models;
using Microsoft.Extensions.Configuration;
using MovieSys.Contracts.Movie;

namespace MovieSys.Tests;

public class CastServiceTest
{
    private readonly CastService _castService;
    private readonly IConfiguration _configuration;

    public CastServiceTest()
    {
        _castService = new CastService();
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();
    }

    [Test]
    public void GetAllCast_Works()
    {
        string id = "9a2adc60-a772-4495-8290-d39e653a0228";
        List<CastResponse> cast = new() { new CastResponse("Sam Worthington", "Jake Sully") };

        List<CastResponse> castMembers = _castService.GetAllCast(id, _configuration["ConnectionStrings:Default"]);

        Assert.That(cast, Is.EqualTo(castMembers));
    }

    [Test]
    public void FindCastMember_Works()
    {
        CastRequest realCast = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), "Sam Worthington", "Jake Sully");
        CastRequest fakeCast = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), "Chris Rock", "Mooseblood");

        bool found = _castService.FindCastMember(realCast, _configuration["ConnectionStrings:Default"]);
        bool notFound = _castService.FindCastMember(fakeCast, _configuration["ConnectionStrings:Default"]);

        Assert.IsFalse(notFound);
        Assert.IsTrue(found);
    }

    [Test]
    public void CreateCast_Works()
    {
        Casts cast = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), "Zoe Saldana", "Neytiri");

        _castService.CreateCast(cast, _configuration["ConnectionStrings:Default"]);
        bool found = _castService.FindCastMember(new CastRequest(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), "Zoe Saldana", "Neytiri"), _configuration["ConnectionStrings:Default"]);

        Assert.IsTrue(found);
    }

    // [Test]
    // public void DeleteCastMember_Work()
    // {

    // }
}