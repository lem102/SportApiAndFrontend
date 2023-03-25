using SportsApi.Database;

namespace SportsApi.Repositories;

public interface IPersonRepository
{
    IEnumerable<Person> GetPeople();
    Person? GetPerson(int id);
}

