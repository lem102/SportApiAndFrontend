using SportsApi.Models;

namespace SportsApi.Repositories;

public interface IPersonRepository
{
    IEnumerable<Person> GetPeople();
}

