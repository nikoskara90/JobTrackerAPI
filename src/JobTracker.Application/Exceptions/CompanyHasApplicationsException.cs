
namespace JobTracker.Application.Exceptions;

public class CompanyHasApplicationsException : Exception
{
    public CompanyHasApplicationsException(Guid companyId)
        : base(
            $"Company '{companyId}' cannot be deleted because it has associated job applications.")
    {
    }
}
