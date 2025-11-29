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

    // Create tmp instance of GenresClient and retrive the
    // all genres(GetGenres) and add them to the array(genres)
    private readonly Genre[] genres = new GenresClient().GetGenres();

    // Goes from a list to an array
    public GameSummary[] GetGames() => [.. games];

    // 
    public void AddGame(GameDetail game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
        };

        games.Add(gameSummary);
    }
    public GameDetail GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetail
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = game.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };

    }

    public void UpdateGame(GameDetail updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }

};