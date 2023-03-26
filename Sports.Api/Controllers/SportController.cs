using Microsoft.AspNetCore.Mvc;
using Sports.Response.Models;
using Sports.Api.Services;

namespace Sports.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SportController : ControllerBase
{
    private ISportService _sportService;

    public SportController(ISportService sportService)
    {
        _sportService = sportService;
    }

    [HttpGet(Name = "GetSportsWithFavouriteCount")]
    public IEnumerable<SportWithFavouriteCountResponse> Get()
    {
        return _sportService.GetSportsWithFavouriteCount();
    }
}
