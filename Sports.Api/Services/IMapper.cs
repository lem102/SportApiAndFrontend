using Sports.Api.Database;
using Sports.Response.Models;

namespace Sports.Api.Services;

public interface IMapper
{
    PersonResponse MapToPerson(Person person);
    SportResponse MapToSport(Sport sport);
    SportWithFavouriteCountResponse MapToSportWithFavouriteCountResponse(Sport sport);
}

