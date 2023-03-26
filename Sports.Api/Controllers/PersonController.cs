using Microsoft.AspNetCore.Mvc;
using Sports.Response.Models;
using Sports.Api.Services;

namespace Sports.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private IPersonService _personService;
    private IMapper _mapper;

    public PersonController(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PersonResponse>> GetPeople()
    {
        var people = _personService.GetPeople();
        var personResponse = people.Select(person => _mapper.MapToPerson(person)).ToArray();
        return Ok(personResponse);
    }

    [HttpGet("{id}")]
    public ActionResult<PersonResponse> GetPerson(int id)
    {
        var person = _personService.GetPerson(id);
        if (person is null)
        {
            return NotFound("Person does not exist");
        }
        var personResponses = _mapper.MapToPerson(person);
        return Ok(personResponses);
    }
}
