using Microsoft.EntityFrameworkCore;
using SportsApi.Models;

namespace SportsApi.Repositories;

class PersonRepository : IPersonRepository
{
    private TappittechnicaltestContext _context;

    public PersonRepository(TappittechnicaltestContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetPeople() => _context.People.Include(x => x.Sports).ToList();
}
