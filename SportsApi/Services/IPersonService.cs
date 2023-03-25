using SportsModels;

namespace SportsApi.Services;

public interface IPersonService
{
    IEnumerable<Person> GetPeople();
    Person? GetPerson(int personId);
}

