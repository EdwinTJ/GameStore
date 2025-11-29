using GameStore.Models;

namespace GameStore.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
    [
        new GameSummary
        {
            Id = 1,
            Name = "GTA 5",
            Genre = "Fighting",
            Price = 89.99M,
            ReleaseDate = new DateOnly(2013, 7, 17),
        },
        new GameSummary
        {
            Id = 2,
            Name = "Fornite",
            Genre = "Battle Royale",
            Price = 50.00M,
            ReleaseDate = new DateOnly(2015, 4, 17),
        },
        new GameSummary
        {
            Id = 3,
            Name = "Fifa",
            Genre = "Sport",
            Price = 79.99M,
            ReleaseDate = new DateOnly(2010, 2, 17),
        }
    ];

    // Goes from a list to an array
    public GameSummary[] GetGames() => [..games];
}