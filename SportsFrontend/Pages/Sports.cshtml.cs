using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsModels;

namespace SportsFrontend.Pages;

public class SportsModel : PageModel
{
    private IHttpClientFactory _httpClientFactory;

    public SportWithFavouriteCount[] Sports { get; private set; }

    public SportsModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        Sports = new SportWithFavouriteCount[0];
    }

    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("Api");
        Sports = await GetSports(httpClient);

    }

    private async Task<SportWithFavouriteCount[]> GetSports(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync("Sport");
        var sports = await response.Content.ReadFromJsonAsync<SportWithFavouriteCount[]>();

        return sports is null
            ? new SportWithFavouriteCount[0]
            : sports;
    }
}
