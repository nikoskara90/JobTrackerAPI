
using JobTracker.Application.Interfaces;
using JobTracker.Domain.Entities;

namespace JobTracker.Application.UseCases.Companies;

public class CreateCompany
{
    private readonly ICompanyRepository _repository;

    public CreateCompany(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync(
        string name,
        string? website)
    {
        var company = new Company(name, website);

        await _repository.AddAsync(company);
        await _repository.SaveChangesAsync();

        return company.Id;
    }
}
