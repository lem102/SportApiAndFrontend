using Microsoft.EntityFrameworkCore;
using Sports.Api.Database;

namespace Sports.Api.Repositories;

class SportRepository : ISportRepository
{
    private SportContext _context;

    public SportRepository(SportContext context)
    {
        _context = context;
    }

    public IEnumerable<Sport> GetSports() => _context.Sports.Include(x => x.People).ToList();
}
