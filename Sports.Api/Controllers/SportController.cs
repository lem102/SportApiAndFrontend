using Microsoft.AspNetCore.Mvc;
using Sports.Response.Models;
using Sports.Api.Services;

namespace Sports.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SportController : ControllerBase
{
    private ISportService _sportService;
    private IMapper _mapper;

    public SportController(ISportService sportService, IMapper personMapper)
    {
        _sportService = sportService;
        _mapper = personMapper;
    }

    [HttpGet(Name = "GetSportsWithFavouriteCount")]
    public ActionResult<IEnumerable<SportWithFavouriteCountResponse>> Get()
    {
        var sports = _sportService.GetSports();
        var sportResponse = sports.Select(sport => _mapper.MapToSportWithFavouriteCountResponse(sport)).ToArray();
        return Ok();
    }
}
