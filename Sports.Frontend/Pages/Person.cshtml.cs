using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sports.Response.Models;

namespace Sports.Frontend.Pages;

public class PersonModel : PageModel
{
    private IHttpClientFactory _httpClientFactory;

    public PersonResponse Person { get; private set; }

    public PersonModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync(int id)
    {
        var httpClient = _httpClientFactory.CreateClient("Api");
        Person = await GetPerson(httpClient, id);
    }

    private async Task<PersonResponse> GetPerson(HttpClient httpClient, int personId)
    {
        var response = await httpClient.GetAsync($"Person/{personId}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new HttpRequestException("404 not found");
        }
        var person = await response.Content.ReadFromJsonAsync<PersonResponse>();
        if (person is null) {
            throw new Exception("invalid response body");
        }
        return person;
    }
}
