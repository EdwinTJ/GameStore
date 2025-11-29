namespace GameStore.Models;

public class GameDetail
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? GenreId { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }

}