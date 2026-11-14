
using JobTracker.Domain.Enums;

namespace JobTracker.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; private set; }

    public Guid CompanyId { get; private set; }

    public string Position { get; private set; }

    public ApplicationStatus Status { get; private set; }

    public DateTime AppliedAt { get; private set; }

    public JobApplication(Guid companyId, string position)
    {
        if (companyId == Guid.Empty)
        {
            throw new ArgumentException(
                "Company ID cannot be empty.",
                nameof(companyId));
        }

        if (string.IsNullOrWhiteSpace(position))
        {
            throw new ArgumentException(
                "Position cannot be empty.",
                nameof(position));
        }

        Id = Guid.NewGuid();
        CompanyId = companyId;
        Position = position.Trim();
        Status = ApplicationStatus.Applied;
        AppliedAt = DateTime.UtcNow;
    }


    public void ChangeStatus(ApplicationStatus newStatus)
    {

        if (!Enum.IsDefined(newStatus))
            throw new ArgumentException(
            "Invalid application status.",
            nameof(newStatus));

        Status = newStatus;

    }

}

