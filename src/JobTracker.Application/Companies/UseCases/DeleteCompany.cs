using JobTracker.Application.Interfaces;

namespace JobTracker.Application.Companies.UseCases;

public class DeleteCompany
{
    private readonly ICompanyRepository _companyRepository;

    public DeleteCompany(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id)
    {
        var company = await _companyRepository
            .GetByIdTrackedAsync(id);

        if (company is null)
        {
            return false;
        }

        _companyRepository.Remove(company);

        await _companyRepository.SaveChangesAsync();

        return true;
    }
}
