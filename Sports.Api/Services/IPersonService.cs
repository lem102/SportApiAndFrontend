using Sports.Response.Models;

namespace Sports.Api.Services;

public interface IPersonService
{
    IEnumerable<PersonResponse> GetPeople();
    PersonResponse? GetPerson(int personId);
}

