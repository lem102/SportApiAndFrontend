using Microsoft.AspNetCore.Mvc.RazorPages;
using Sports.Response.Models;

namespace Sports.Frontend.Pages;

public class SportsModel : PageModel
{
    private IHttpClientFactory _httpClientFactory;

    public SportWithFavouriteCountResponse[] Sports { get; private set; }

    public SportsModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        Sports = new SportWithFavouriteCountResponse[0];
    }

    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("Api");
        Sports = await GetSports(httpClient);

    }

    private async Task<SportWithFavouriteCountResponse[]> GetSports(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync("Sport");
        var sports = await response.Content.ReadFromJsonAsync<SportWithFavouriteCountResponse[]>();

        return sports is null
            ? new SportWithFavouriteCountResponse[0]
            : sports;
    }
}
