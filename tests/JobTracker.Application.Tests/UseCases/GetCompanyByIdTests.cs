
using JobTracker.Application.Tests.Fakes;
using JobTracker.Application.Companies.UseCases;
using JobTracker.Domain.Entities;

namespace JobTracker.Application.Tests.UseCases;

public class GetCompanyByIdTests
{
    [Fact]
    public async Task ExecuteAsync_ExistingCompany_ReturnsCompanyResponse()
    {
        // Arrange
        var repository = new FakeCompanyRepository();

        var company = new Company(
            "Google",
            "https://google.com"
        );

        repository.Companies.Add(company);

        var useCase = new GetCompanyById(repository);

        // Act
        var result = await useCase.ExecuteAsync(company.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(company.Id, result.Id);
        Assert.Equal(company.Name, result.Name);
        Assert.Equal(company.Website, result.Website);
        Assert.Equal(company.CreatedAt, result.CreatedAt);
    }

    [Fact]
    public async Task ExecuteAsync_NonExistingCompany_ReturnsNull()
    {
        // Arrange
        var repository = new FakeCompanyRepository();
        var useCase = new GetCompanyById(repository);

        var unknownId = Guid.NewGuid();

        // Act
        var result = await useCase.ExecuteAsync(unknownId);

        // Assert
        Assert.Null(result);
    }
}
