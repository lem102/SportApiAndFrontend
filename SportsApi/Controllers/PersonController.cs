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

    [HttpGet(Name = "GetPeople")]
    public IEnumerable<Person> Get()
    {
        return _personService.GetPeople();
    }
}
