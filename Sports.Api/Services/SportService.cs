using Sports.Api.Repositories;
using Sports.Api.Database;

namespace Sports.Api.Services;

public class SportService : ISportService
{
    private ISportRepository _sportRepository;

    public SportService(ISportRepository sportRepository)
    {
        _sportRepository = sportRepository;
    }

    public IEnumerable<Sport> GetSports() => _sportRepository.GetSports();
}
