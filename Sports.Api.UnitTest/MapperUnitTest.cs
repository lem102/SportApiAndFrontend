using NSubstitute;
using Sports.Api.Database;
using Sports.Api.Repositories;
using Sports.Api.Services;
using Sports.Response.Models;

namespace Sports.Api.UnitTest;

public class MapperUnitTest
{
    [Test]
    public void MapToPerson_PersonGiven_PersonResponseReturned()
    {
        var systemUnderTest = new Mapper();
        
        var personId = 5;
        var firstName = "testy";
        var lastName = "testerton";
        var isAuthorised = true;
        var isValid = false;
        var isEnabled = true;
        var sports = Array.Empty<Sport>();
        var sportResponses = Array.Empty<SportResponse>();

        var person = new Person
        {
            PersonId = personId,
            FirstName = firstName,
            LastName = lastName,
            IsAuthorised = isAuthorised,
            IsValid = isValid,
            IsEnabled = isEnabled,
            Sports = sports
        };

        var personResponse = new PersonResponse(
            personId,
            firstName,
            lastName,
            isAuthorised,
            isValid,
            isEnabled,
            sportResponses
        );

        var result = systemUnderTest.MapToPerson(person);

        Assert.That(result, Is.EqualTo(personResponse));
    }

    [Test]
    public void MapToSport_SportGiven_SportResponseReturned()
    {
        var systemUnderTest = new Mapper();
        
        var sportId = 5;
        var name = "sportName";
        var isEnabled = true;
        var people = Array.Empty<Person>();

        var sport = new Sport
        {
            SportId = sportId,
            Name = name,
            IsEnabled = isEnabled,
            People = people
        };

        var personResponse = new SportResponse(
            sportId,
            name,
            isEnabled
        );

        var result = systemUnderTest.MapToSport(sport);

        Assert.That(result, Is.EqualTo(personResponse));
    }

    [Test]
    public void MapToSportWithFavouriteCountResponse_SportGiven_SportWithFavouriteCountResponseReturned()
    {
        var systemUnderTest = new Mapper();
        
        var sportId = 5;
        var name = "sportName";
        var isEnabled = true;
        var people = new Person[]{
            new Person{},
            new Person{},
            new Person{}
        };

        var sport = new Sport
        {
            SportId = sportId,
            Name = name,
            IsEnabled = isEnabled,
            People = people
        };

        var sportWithFavouriteCountResponse = new SportWithFavouriteCountResponse(
            sportId,
            name,
            isEnabled,
            people.Count()
        );

        var result = systemUnderTest.MapToSportWithFavouriteCountResponse(sport);

        Assert.That(result, Is.EqualTo(sportWithFavouriteCountResponse));
    }
}
