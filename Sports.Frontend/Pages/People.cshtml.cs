using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sports.Response.Models;

namespace Sports.Frontend.Pages;

public class PeopleModel : PageModel
{
    private IHttpClientFactory _httpClientFactory;

    public PersonResponse[] People { get; private set; }

    public int PersonId { get; set; }

    public PeopleModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        People = new PersonResponse[0];
    }

    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("Api");
        People = await GetPeople(httpClient);
    }

    private async Task<PersonResponse[]> GetPeople(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync("Person");
        var people = await response.Content.ReadFromJsonAsync<PersonResponse[]>();

        return people is null
            ? new PersonResponse[0]
            : people;
    }
}
