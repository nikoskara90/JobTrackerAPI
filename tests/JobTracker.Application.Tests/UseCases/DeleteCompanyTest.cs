
using JobTracker.Application.Companies.UseCases;
using JobTracker.Application.Tests.Fakes;
using JobTracker.Domain.Entities;

namespace JobTracker.Application.Tests.UseCases.Companies;

public class DeleteCompanyTests
{
    [Fact]
    public async Task ExecuteAsync_WhenCompanyExists_DeletesCompany()
    {
        // Arrange
        var repository = new FakeCompanyRepository();
        var company = new Company("Microsoft", "https://microsoft.com");

        await repository.AddAsync(company);

        var useCase = new DeleteCompany(repository);

        // Act
        var result = await useCase.ExecuteAsync(company.Id);

        // Assert
        Assert.True(result);
        Assert.DoesNotContain(
            repository.Companies,
            c => c.Id == company.Id);
    }

    [Fact]
    public async Task ExecuteAsync_WhenCompanyDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var repository = new FakeCompanyRepository();
        var useCase = new DeleteCompany(repository);

        // Act
        var result = await useCase.ExecuteAsync(Guid.NewGuid());

        // Assert
        Assert.False(result);
        Assert.Empty(repository.Companies);
    }
}
