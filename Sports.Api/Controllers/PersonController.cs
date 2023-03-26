using Microsoft.AspNetCore.Mvc;
using Sports.Response.Models;
using Sports.Api.Services;

namespace Sports.Api.Controllers;

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
    public IEnumerable<PersonResponse> GetPeople()
    {
        return _personService.GetPeople();
    }

    [HttpGet("{id}")]
    public PersonResponse? GetPerson(int id)
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
