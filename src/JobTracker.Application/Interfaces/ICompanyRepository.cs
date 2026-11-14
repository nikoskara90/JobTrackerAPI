
using JobTracker.Domain.Entities;

namespace JobTracker.Application.Interfaces;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(Guid id);

    Task<List<Company>> GetAllAsync();

    Task AddAsync(Company company);
    
    Task SaveChangesAsync();
}
