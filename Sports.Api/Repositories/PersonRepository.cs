using Microsoft.EntityFrameworkCore;
using Sports.Api.Database;

namespace Sports.Api.Repositories;

public class PersonRepository : IPersonRepository
{
    private Database.SportContext _context;

    public PersonRepository(Database.SportContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetPeople() => _context.People.Include(x => x.Sports).ToList();

    public Person? GetPerson(int id) => _context.People.Include(x => x.Sports).FirstOrDefault(x => x.PersonId == id);
}
