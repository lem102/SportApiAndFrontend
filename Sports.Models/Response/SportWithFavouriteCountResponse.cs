namespace Sports.Response.Models;

public record class SportWithFavouriteCountResponse(int SportId, string Name, bool IsEnabled, int Favourites);

