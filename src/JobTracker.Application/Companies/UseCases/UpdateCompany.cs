using JobTracker.Application.Interfaces;

namespace JobTracker.Application.Companies.UseCases;

public class UpdateCompany
{
    private readonly ICompanyRepository _repository;

    public UpdateCompany(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(
        Guid id,
        string name,
        string? website)
    {
        // Step 1: Retrieve the company with tracking
        var company = await _repository.GetByIdTrackedAsync(id);

        // Step 2: Check if it exists
        if (company is null)
        {
            return false;
        }

        // Step 3: Update its properties
        company.Rename(name);
        company.UpdateWebsite(website);

        // Step 4: Save changes
        await _repository.SaveChangesAsync();

        // Step 5: Return success
        return true;
    }
}
