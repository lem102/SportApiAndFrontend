using SportsApi.Models;

namespace SportsApi.Services;

public interface IPersonService
{
    IEnumerable<Person> GetPeople();
    Person? GetPerson(int personId);
}

