using Sports.Response.Models;
using Sports.Api.Repositories;

namespace Sports.Api.Services;

public class SportService : ISportService
{
    private ISportRepository _sportRepository;

    public SportService(ISportRepository sportRepository)
    {
        _sportRepository = sportRepository;
    }

    public IEnumerable<SportWithFavouriteCountResponse> GetSportsWithFavouriteCount()
    {
        var sports = _sportRepository.GetSports();
        return sports.Select(sport =>
        {
            var favourites = sport.People.Count();
            return new SportWithFavouriteCountResponse(
                sport.SportId,
                sport.Name,
                sport.IsEnabled,
                favourites);
        }).ToArray();
    }
}
