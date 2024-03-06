using System.ComponentModel.DataAnnotations;

namespace swagger_docs.Models;

public record Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(10, ErrorMessage = "First name must not exceed 10 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(10, ErrorMessage = "Last name must not exceed 10 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Position is required.")]
    public string Position { get; set; }
}