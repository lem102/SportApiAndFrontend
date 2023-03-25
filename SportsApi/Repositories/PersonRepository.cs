using Microsoft.EntityFrameworkCore;
using SportsApi.Database;

namespace SportsApi.Repositories;

public class PersonRepository : IPersonRepository
{
    private Database.TappittechnicaltestContext _context;

    public PersonRepository(Database.TappittechnicaltestContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetPeople() => _context.People.Include(x => x.Sports).ToList();

    public Person? GetPerson(int id) => _context.People.Include(x => x.Sports).FirstOrDefault(x => x.PersonId == id);
}
