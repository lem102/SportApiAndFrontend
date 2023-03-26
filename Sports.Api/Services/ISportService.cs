using Sports.Api.Database;

namespace Sports.Api.Services;

public interface ISportService
{
    IEnumerable<Sport> GetSports();
}

