using SportsApi.Models;
using SportsApi.Repositories;

namespace SportsApi.Services;

class PersonService : IPersonService
{
    private IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public IEnumerable<Person> GetPeople()
    {
        return _personRepository.GetPeople();
    }
}
