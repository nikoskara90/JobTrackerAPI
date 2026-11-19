using JobTracker.Application.Companies.DTOs;
using JobTracker.Application.Interfaces;

namespace JobTracker.Application.Companies.UseCases;

public class GetCompanyById
{
    private readonly ICompanyRepository _repository;

    public GetCompanyById(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<CompanyResponse?> ExecuteAsync(Guid id)
    {
        var company = await _repository.GetByIdAsync(id);

        if (company is null)
        {
            return null;
        }

        return new CompanyResponse(
            company.Id,
            company.Name,
            company.Website,
            company.CreatedAt
        );
    }
}
