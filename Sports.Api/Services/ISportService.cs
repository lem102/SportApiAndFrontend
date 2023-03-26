using Sports.Response.Models;

namespace Sports.Api.Services;

public interface ISportService
{
    IEnumerable<SportWithFavouriteCountResponse> GetSportsWithFavouriteCount();
}

