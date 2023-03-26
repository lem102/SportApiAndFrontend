using Sports.Api.Database;
using Sports.Response.Models;

namespace Sports.Api.Services;

public class Mapper : IMapper
{
    public PersonResponse MapToPerson(Person person) => new PersonResponse(
        person.PersonId,
        person.FirstName,
        person.LastName,
        person.IsAuthorised,
        person.IsValid,
        person.IsEnabled,
        person.Sports.Select(sport => MapToSport(sport)).ToArray()
    );

    public SportResponse MapToSport(Sport databaseSport) => new SportResponse(
        databaseSport.SportId,
        databaseSport.Name,
        databaseSport.IsEnabled
    );

    public SportWithFavouriteCountResponse MapToSportWithFavouriteCountResponse(Sport sport)
    {
        var favourites = sport.People.Count();
        return new SportWithFavouriteCountResponse(
            sport.SportId,
            sport.Name,
            sport.IsEnabled,
            favourites
        );
    }
}
