using Sports.Api.Database;

namespace Sports.Api.Repositories;

public interface IPersonRepository
{
    IEnumerable<Person> GetPeople();
    Person? GetPerson(int id);
}

