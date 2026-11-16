
using JobTracker.Application.DTOs;
using JobTracker.Application.Interfaces;

namespace JobTracker.Application.UseCases.Companies;

public class GetAllCompanies
{
    private readonly ICompanyRepository _repository;

    public GetAllCompanies(ICompanyRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<CompanyResponse>> ExecuteAsync()
    {
        var companies = await _repository.GetAllAsync();

        var responses = companies
            .Select(c => new CompanyResponse(
                c.Id,
                c.Name,
                c.Website,
                c.CreatedAt
            ))
            .ToList();

        return responses;
    }

}
