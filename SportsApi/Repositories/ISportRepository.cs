using SportsApi.Database;

namespace SportsApi.Repositories;

public interface ISportRepository
{
    IEnumerable<Sport> GetSports();
}

