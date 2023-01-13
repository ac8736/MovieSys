using Microsoft.AspNetCore.Mvc;
using MovieSys.Contracts.Movie;
using MovieSys.Models;
using MovieSys.Services;

namespace MovieSys.Controllers;

public class UserController : ApiController
{
    private readonly IUserService _user;

    public UserController(IUserService user, IConfiguration configuration) : base(configuration)
        => _user = user;

    [HttpGet("{id}")]
    public IActionResult FindUser(string id)
    {
        var user = _user.FindUser(id, _configuration["ConnectionStrings:Default"]);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult RegisterUser(UserRequest request)
    {
        var user = new User(Guid.NewGuid(), request.Email, request.Username, request.Password);
        _user.CreateUser(user, _configuration["ConnectionStrings:Default"]);
        var response = new UserResponse(user.Id, user.Email, user.Username);
        return CreatedAtAction(actionName: nameof(FindUser), routeValues: new { id = user.Id }, value: response);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(string id)
    {
        if (_user.FindUser(id, _configuration["ConnectionStrings:Default"]) == null)
            return NotFound();
        _user.DeleteUser(id, _configuration["ConnectionStrings:Default"]);
        return NoContent();
    }
}
