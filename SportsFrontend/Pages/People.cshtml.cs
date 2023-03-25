using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsModels;

namespace SportsFrontend.Pages;

public class PeopleModel : PageModel
{
    private IHttpClientFactory _httpClientFactory;

    public Person[] People { get; private set; }

    public int PersonId { get; set; }

    public PeopleModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        People = new Person[0];
    }

    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("Api");
        People = await GetPeople(httpClient);
    }

    private async Task<Person[]> GetPeople(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync("Person");
        var people = await response.Content.ReadFromJsonAsync<Person[]>();

        return people is null
            ? new Person[0]
            : people;
    }
}
