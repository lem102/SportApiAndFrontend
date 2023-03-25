using SportsApi.Repositories;
using SportsModels;

namespace SportsApi.Services;

public class PersonService : IPersonService
{
    private IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public IEnumerable<Person> GetPeople()
    {
        var databasePeople = _personRepository.GetPeople();
        return databasePeople.Select(person => mapDatabasePersonToModel(person));
    }

    public Person? GetPerson(int personId)
    {
        var databasePerson = _personRepository.GetPerson(personId);
        if (databasePerson is null) {
            return null;
        }
        return mapDatabasePersonToModel(databasePerson);
    }

    private Person mapDatabasePersonToModel(Database.Person databasePerson) => new Person(
        databasePerson.PersonId,
        databasePerson.FirstName,
        databasePerson.LastName,
        databasePerson.IsAuthorised,
        databasePerson.IsValid,
        databasePerson.IsEnabled,
        databasePerson.Sports.Select(sport => mapDatabaseSportToModel(sport)).ToArray()
    );

    private Sport mapDatabaseSportToModel(Database.Sport databaseSport) => new Sport(
        databaseSport.SportId,
        databaseSport.Name,
        databaseSport.IsEnabled
    );
}
