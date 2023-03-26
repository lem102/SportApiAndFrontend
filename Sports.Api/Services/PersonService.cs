using Sports.Api.Database;
using Sports.Api.Repositories;

namespace Sports.Api.Services;

public class PersonService : IPersonService
{
    private IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public IEnumerable<Person> GetPeople() => _personRepository.GetPeople();

    public Person? GetPerson(int personId)
    {
        var databasePerson = _personRepository.GetPerson(personId);
        if (databasePerson is null)
        {
            return null;
        }
        return databasePerson;
    }
}
