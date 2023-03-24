using SportsApi.Models;

namespace SportsApi.Services;

public interface ISportService
{
    IEnumerable<SportWithFavouriteCount> GetSportsWithFavouriteCount();
}

