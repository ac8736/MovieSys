using NUnit.Framework;
using MovieSys.Services;
using MovieSys.Models;
using Microsoft.Extensions.Configuration;
using MovieSys.Contracts.Movie;

namespace MovieSys.Tests;

public class UserServiceTest
{
    private readonly UserService userService;
    private readonly IConfiguration _configuration;

    public UserServiceTest()
    {
        userService = new UserService();
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();
    }

    [Test]
    public void FindUser_Works()
    {
        string knownId = "682671f8-00f1-4155-8416-8b4f3ff97126";
        UserResponse response = new(new Guid("682671f8-00f1-4155-8416-8b4f3ff97126"), "test@test.com", "test");
        string unknownId = "00000000-0000-0000-0000-000000000000";

        UserResponse? foundUser = userService.FindUser(knownId, _configuration["ConnectionStrings:Default"]);
        UserResponse? unfoundUser = userService.FindUser(unknownId, _configuration["ConnectionStrings:Default"]);

        Assert.AreSame(unfoundUser, null);
        Assert.AreNotSame(foundUser, null);
        if (foundUser != null)
            Assert.That(foundUser.Id, Is.EqualTo(response.Id));
    }
}
