using Microsoft.AspNetCore.Mvc;

namespace MovieSys.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    protected readonly IConfiguration _configuration;

    public ApiController(IConfiguration configuration)
        => _configuration = configuration;
}