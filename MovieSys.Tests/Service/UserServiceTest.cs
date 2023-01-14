using NUnit.Framework;
using MovieSys.Services;
using MovieSys.Models;
using Microsoft.Extensions.Configuration;
using MovieSys.Contracts.Movie;

namespace MovieSys.Tests;

public class UserServiceTest
{
    private readonly UserService _userService;
    private readonly IConfiguration _configuration;

    public UserServiceTest()
    {
        _userService = new UserService();
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

        UserResponse? foundUser = _userService.FindUser(knownId, _configuration["ConnectionStrings:Default"]);
        UserResponse? unfoundUser = _userService.FindUser(unknownId, _configuration["ConnectionStrings:Default"]);

        Assert.AreSame(unfoundUser, null);
        Assert.AreNotSame(foundUser, null);
        if (foundUser != null)
            Assert.That(foundUser.Id, Is.EqualTo(response.Id));
    }

    [Test]
    public void CreateUser_Works()
    {
        User user = new(new Guid("8595f2da-9793-45c3-8253-2f9b2007a37e"), "user@mail.com", "user", "password");

        _userService.CreateUser(user, _configuration["ConnectionStrings:Default"]);
        UserResponse? foundUser = _userService.FindUser(user.Id.ToString(), _configuration["ConnectionStrings:Default"]);

        if (foundUser != null)
            Assert.That(foundUser.Id, Is.EqualTo(user.Id));
    }

    [Test]
    public void DeleteUser_Works()
    {
        string id = "8595f2da-9793-45c3-8253-2f9b2007a37e";

        _userService.DeleteUser(id, _configuration["ConnectionStrings:Default"]);
        UserResponse? unfoundUser = _userService.FindUser(id, _configuration["ConnectionStrings:Default"]);

        Assert.AreSame(unfoundUser, null);
    }
}

