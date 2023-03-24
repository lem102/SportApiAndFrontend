using SportsApi.Models;
using SportsApi.Repositories;

namespace SportsApi.Services;

public class SportService : ISportService
{
    private ISportRepository _sportRepository;

    public SportService(ISportRepository sportRepository)
    {
        _sportRepository = sportRepository;
    }

    public IEnumerable<SportWithFavouriteCount> GetSportsWithFavouriteCount()
    {
        var sports = _sportRepository.GetSports();
        return sports.Select(sport =>
        {
            var favourites = sport.People.Count();
            return new SportWithFavouriteCount(
                sport.SportId,
                sport.Name,
                sport.IsEnabled,
                favourites);
        }).ToArray();
    }
}
