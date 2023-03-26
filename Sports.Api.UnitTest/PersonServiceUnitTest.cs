using NSubstitute;
using Sports.Api.Repositories;
using Sports.Api.Services;
using Sports.Api.Database;

namespace Sports.Api.UnitTest;

public class PersonServiceUnitTest
{
    [Test]
    public void GetPeople_NoPeopleInDatabase_NoPeopleReturned()
    {
        var repository = Substitute.For<IPersonRepository>();
        var people = new List<Person>{};
        repository.GetPeople().Returns(people);
        var systemUnderTest = new PersonService(repository);

        var result = systemUnderTest.GetPeople();

        Assert.That(result.Count(), Is.EqualTo(0));
    }

    [Test]
    public void GetPeople_PopulatedDatabase_PeopleReturned()
    {
        var repository = Substitute.For<IPersonRepository>();
        var person = new Person
        {
            PersonId = 3,
            Sports = new List<Sport>{
                new Sport
                {
                    SportId = 5,
                }
            }
        };
        var people = new List<Person>{
            person,
            new Person{},
            new Person{}
        };
        repository.GetPeople().Returns(people);
        
        var systemUnderTest = new PersonService(repository);
        var result = systemUnderTest.GetPeople().ToArray();

        Assert.That(result.Count(), Is.EqualTo(people.Count()));
        Assert.That(result[0].PersonId, Is.EqualTo(person.PersonId));
        Assert.That(result[0].Sports.Count(), Is.EqualTo(person.Sports.Count()));
    }

    [Test]
    public void GetPerson_InvalidId_NullReturned()
    {
        var repository = Substitute.For<IPersonRepository>();
        repository.GetPerson(26).Returns(_ => null);
        
        var systemUnderTest = new PersonService(repository);
        var result = systemUnderTest.GetPerson(26);

        Assert.That(result, Is.EqualTo(null));
    }

    [Test]
    public void GetPerson_ValidId_PeopleReturned()
    {
        var repository = Substitute.For<IPersonRepository>();
        var personId = 3;
        var sport = new Sport
        {
            SportId = 5,
        };
        var person = new Person
        {
            PersonId = personId,
            Sports = new List<Sport>{
                sport
            }
        };
        repository.GetPerson(personId).Returns(person);
        
        var systemUnderTest = new PersonService(repository);
        var result = systemUnderTest.GetPerson(personId);

        Assert.That(result!.PersonId, Is.EqualTo(person.PersonId));
        Assert.That(result.Sports.Count(), Is.EqualTo(person.Sports.Count()));
    }
}
