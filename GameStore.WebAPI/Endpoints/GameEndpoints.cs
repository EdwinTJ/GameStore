using GameStore.WebAPI.Dtos;

namespace GameStore.WebAPI.Endpoints;
public static class GameEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
     new
        (
            1,
            "GTA 5",
            "Fighting",
            89.99M,
           new DateOnly(2013, 7, 17)
        ),
        new
        (
             2,
            "Fornite",
            "Battle Royale",
            50.00M,
            new DateOnly(2015, 4, 17)
        ),
        new
        (
            3,
            "Fifa",
            "Sport",
            79.99M,
            new DateOnly(2010, 2, 17)
        )
    ];


    public static RouteGroupBuilder MapGamesEndpoints(this  WebApplication app)
    {

        var group = app.MapGroup("games");

        // GET /games
        group.MapGet("/", () => games);

        // GET /games/id
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);

        })
        .WithName(GetGameEndpointName);

        // Post /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate);

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        // PUT /games
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(games => games.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updateGame.Name,
                updateGame.Genre,
                updateGame.Price,
                updateGame.ReleaseDate
                );

            return Results.NoContent();

        });

        // DELETE /games
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }

}
