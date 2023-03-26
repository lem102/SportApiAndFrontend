using Sports.Models;

namespace Sports.Api.Services;

public interface ISportService
{
    IEnumerable<SportWithFavouriteCount> GetSportsWithFavouriteCount();
}

