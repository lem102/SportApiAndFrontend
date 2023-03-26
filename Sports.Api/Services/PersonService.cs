using Sports.Api.Repositories;
using Sports.Response.Models;

namespace Sports.Api.Services;

public class PersonService : IPersonService
{
    private IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public IEnumerable<PersonResponse> GetPeople()
    {
        var databasePeople = _personRepository.GetPeople();
        return databasePeople.Select(person => mapDatabasePersonToModel(person));
    }

    public PersonResponse? GetPerson(int personId)
    {
        var databasePerson = _personRepository.GetPerson(personId);
        if (databasePerson is null) {
            return null;
        }
        return mapDatabasePersonToModel(databasePerson);
    }

    private PersonResponse mapDatabasePersonToModel(Database.Person databasePerson) => new PersonResponse(
        databasePerson.PersonId,
        databasePerson.FirstName,
        databasePerson.LastName,
        databasePerson.IsAuthorised,
        databasePerson.IsValid,
        databasePerson.IsEnabled,
        databasePerson.Sports.Select(sport => mapDatabaseSportToModel(sport)).ToArray()
    );

    private SportResponse mapDatabaseSportToModel(Database.Sport databaseSport) => new SportResponse(
        databaseSport.SportId,
        databaseSport.Name,
        databaseSport.IsEnabled
    );
}
