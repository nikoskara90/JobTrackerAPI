
using JobTracker.Application.Interfaces;
using JobTracker.Domain.Entities;

namespace JobTracker.Application.Tests.Fakes;

public class FakeCompanyRepository : ICompanyRepository
{
    public List<Company> Companies { get; } = new();

    public bool SaveChangesCalled { get; private set; }

    public Task<Company?> GetByIdAsync(Guid id)
    {
        var company = Companies
            .FirstOrDefault(c => c.Id == id);

        return Task.FromResult(company);
    }

    public Task<Company?> GetByIdTrackedAsync(Guid id)
    {
        var company = Companies.FirstOrDefault(c => c.Id == id);

        return Task.FromResult(company);
    }

    public Task<List<Company>> GetAllAsync()
    {
        return Task.FromResult(Companies.ToList());
    }

    public Task AddAsync(Company company)
    {
        Companies.Add(company);

        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        SaveChangesCalled = true;

        return Task.CompletedTask;
    }
}
