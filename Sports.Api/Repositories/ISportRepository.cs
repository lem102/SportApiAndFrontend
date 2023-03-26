using Sports.Api.Database;

namespace Sports.Api.Repositories;

public interface ISportRepository
{
    IEnumerable<Sport> GetSports();
}

