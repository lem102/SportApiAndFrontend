using Microsoft.AspNetCore.Mvc;
using SportsModels;
using SportsApi.Services;

namespace SportsApi.Controllers;

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
    public IEnumerable<SportWithFavouriteCount> Get()
    {
        return _sportService.GetSportsWithFavouriteCount();
    }
}
