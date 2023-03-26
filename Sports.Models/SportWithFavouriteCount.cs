namespace Sports.Models;

public record class SportWithFavouriteCount(int SportId, string Name, bool IsEnabled, int Favourites);

