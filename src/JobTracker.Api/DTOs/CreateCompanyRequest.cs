
using System.ComponentModel.DataAnnotations;

namespace JobTracker.Api.DTOs;

public class CreateCompanyRequest
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Url]
    public string? Website { get; set; }
}
