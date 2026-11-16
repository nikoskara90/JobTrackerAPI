
namespace JobTracker.Application.DTOs;

public record CompanyResponse(
    Guid Id,
    string Name,
    string? Website,
    DateTime CreatedAt
);
