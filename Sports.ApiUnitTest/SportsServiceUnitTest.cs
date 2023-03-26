using NSubstitute;
using Sports.Api.Database;
using Sports.Api.Repositories;
using Sports.Api.Services;

namespace Sports.ApiUnitTest;

public class SportsServiceUnitTest
{
    [Test]
    public void GetSports_NoSportsInDatabase_NoSportsReturned()
    {
        var repository = Substitute.For<ISportRepository>();
        var sports = new List<Sport>{};
        repository.GetSports().Returns(sports);
        var systemUnderTest = new SportService(repository);

        var result = systemUnderTest.GetSports();

        Assert.That(result.Count(), Is.EqualTo(0));
    }

    [Test]
    public void GetSports_PopulatedDatabase_SportsReturnedWithNumberOfTimesFavourited()
    {
        var repository = Substitute.For<ISportRepository>();
        var sport = new Sport
        {
            SportId = 5
        };
        var sports = new List<Sport>
        {
            sport
        };
        repository.GetSports().Returns(sports);        
        
        var systemUnderTest = new SportService(repository);
        var result = systemUnderTest.GetSports().ToArray();

        Assert.That(result.Count(), Is.EqualTo(sports.Count()));
        Assert.That(result[0].SportId, Is.EqualTo(sport.SportId));
    }
}
