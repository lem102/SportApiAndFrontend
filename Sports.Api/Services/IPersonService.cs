using Sports.Api.Database;

namespace Sports.Api.Services;

public interface IPersonService
{
    IEnumerable<Person> GetPeople();
    Person? GetPerson(int personId);
}

