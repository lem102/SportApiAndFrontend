using NSubstitute;
using Sports.Api.Database;
using Sports.Api.Repositories;
using Sports.Api.Services;

namespace Sports.ApiUnitTest;

public class SportsServiceUnitTest
{
    [Test]
    public void GetSportsWithFavouriteCount_NoSportsInDatabase_NoSportsReturned()
    {
        var repository = Substitute.For<ISportRepository>();
        var sports = new List<Sport>{};
        repository.GetSports().Returns(sports);
        var systemUnderTest = new SportService(repository);

        var result = systemUnderTest.GetSportsWithFavouriteCount();

        Assert.That(result.Count(), Is.EqualTo(0));
    }

    [Test]
    public void GetSportsWithFavouriteCount_PopulatedDatabase_SportsReturnedWithNumberOfTimesFavourited()
    {
        var repository = Substitute.For<ISportRepository>();
        var people = new List<Person>{
            new Person{},
            new Person{},
            new Person{}
        };
        var sport = new Sport
        {
            SportId = 5,
            People = people
        };
        var sports = new List<Sport>
        {
            sport
        };
        repository.GetSports().Returns(sports);        
        
        var systemUnderTest = new SportService(repository);
        var result = systemUnderTest.GetSportsWithFavouriteCount().ToArray();

        Assert.That(result.Count(), Is.EqualTo(sports.Count()));
        Assert.That(result[0].SportId, Is.EqualTo(sport.SportId));
        Assert.That(result[0].Favourites, Is.EqualTo(people.Count()));
    }
}
