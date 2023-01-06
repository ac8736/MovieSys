using Microsoft.AspNetCore.Mvc;

namespace MovieSys.Controllers;

public class ErrorController : ApiController
{
    public ErrorController(IConfiguration configuration) : base(configuration) { }
    public IActionResult Error() => Problem();
}