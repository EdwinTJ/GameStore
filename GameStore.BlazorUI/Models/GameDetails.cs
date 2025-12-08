using System.ComponentModel.DataAnnotations;

namespace GameStore.BlazorUI.Models;

public class GameDetail
{
    public int Id { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [StringLength(20,ErrorMessage = "The value {0} can not exceed {1} characters")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "This Genre field is required")]
    public string? GenreId { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Range(1,200, ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public DateOnly ReleaseDate { get; set; }

}