using SportsApi.Repositories;

namespace SportsApi.Services;

public class PersonService : IPersonService
{
    private IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public IEnumerable<Models.Person> GetPeople()
    {
        var databasePeople = _personRepository.GetPeople();
        return databasePeople.Select(person => mapDatabasePersonToModel(person));
    }

    public Models.Person? GetPerson(int personId)
    {
        var databasePerson = _personRepository.GetPerson(personId);
        if (databasePerson is null) {
            return null;
        }
        return mapDatabasePersonToModel(databasePerson);
    }

    private Models.Person mapDatabasePersonToModel(Database.Person databasePerson) => new Models.Person(
        databasePerson.PersonId,
        databasePerson.FirstName,
        databasePerson.LastName,
        databasePerson.IsAuthorised,
        databasePerson.IsValid,
        databasePerson.IsEnabled,
        databasePerson.Sports.Select(sport => mapDatabaseSportToModel(sport)).ToArray()
    );

    private Models.Sport mapDatabaseSportToModel(Database.Sport databaseSport) => new Models.Sport(
        databaseSport.SportId,
        databaseSport.Name,
        databaseSport.IsEnabled
    );
}
