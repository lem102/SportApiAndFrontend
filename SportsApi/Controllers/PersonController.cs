using Microsoft.AspNetCore.Mvc;
using SportsApi.Models;
using SportsApi.Services;

namespace SportsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet()]
    public IEnumerable<Person> GetPeople()
    {
        return _personService.GetPeople();
    }

    [HttpGet("{id}")]
    public Person? GetPerson(int id)
    {
        var person = _personService.GetPerson(id);
        if (person is null)
        {
            Response.StatusCode = 404;
            return null;
        }
        return person;
    }
}
