
using JobTracker.Application.Tests.Fakes;
using JobTracker.Application.UseCases.Companies;
using JobTracker.Domain.Entities;

namespace JobTracker.Application.Tests.UseCases;

public class GetAllCompaniesTests
{
    [Fact]
    public async Task ExecuteAsync_MultipleCompanies_ReturnsAllCompanyResponses()
    {
        // Arrange
        var repository = new FakeCompanyRepository();

        var google = new Company("Google", "https://google.com");
        var microsoft = new Company("Microsoft", "https://microsoft.com");

        repository.Companies.Add(google);
        repository.Companies.Add(microsoft);

        var useCase = new GetAllCompanies(repository);

        // Act
        var result = await useCase.ExecuteAsync();

        // Assert
        Assert.Equal(2, result.Count);

        Assert.Contains(result, c =>
            c.Id == google.Id &&
            c.Name == "Google" &&
            c.Website == "https://google.com"
        );

        Assert.Contains(result, c =>
            c.Id == microsoft.Id &&
            c.Name == "Microsoft" &&
            c.Website == "https://microsoft.com"
        );
    }

    [Fact]
    public async Task ExecuteAsync_NoCompanies_ReturnsEmptyList()
    {
        // Arrange
        var repository = new FakeCompanyRepository();
        var useCase = new GetAllCompanies(repository);

        // Act
        var result = await useCase.ExecuteAsync();

        // Assert
        Assert.Empty(result);
    }
}
