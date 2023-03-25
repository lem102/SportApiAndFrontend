using SportsModels;

namespace SportsApi.Services;

public interface ISportService
{
    IEnumerable<SportWithFavouriteCount> GetSportsWithFavouriteCount();
}

