using Microsoft.EntityFrameworkCore;
using SportsApi.Database;

namespace SportsApi.Repositories;

class SportRepository : ISportRepository
{
    private SportContext _context;

    public SportRepository(SportContext context)
    {
        _context = context;
    }

    public IEnumerable<Sport> GetSports() => _context.Sports.Include(x => x.People).ToList();
}
