
using JobTracker.Application.Tests.Fakes;
using JobTracker.Application.UseCases.Companies;
using JobTracker.Domain.Entities;

namespace JobTracker.Application.Tests.UseCases;

public class UpdateCompanyTests
{
    [Fact]
    public async Task ExecuteAsync_ExistingCompany_UpdatesAndSaves()
    {
        // Arrange
        var repository = new FakeCompanyRepository();

        var company = new Company(
            "Microsoft",
            "https://microsoft.com"
        );

        repository.Companies.Add(company);

        var useCase = new UpdateCompany(repository);

        // Act
        var result = await useCase.ExecuteAsync(
            company.Id,
            "Microsoft Azure",
            "https://azure.microsoft.com"
        );

        // Assert
        Assert.True(result);
        Assert.Equal("Microsoft Azure", company.Name);
        Assert.Equal(
            "https://azure.microsoft.com",
            company.Website
        );
        Assert.True(repository.SaveChangesCalled);
    }


    [Fact]
    public async Task ExecuteAsync_NonExistingCompany_ReturnsFalse()
    {
        // Arrange
        var repository = new FakeCompanyRepository();
        var useCase = new UpdateCompany(repository);

        var unknownId = Guid.NewGuid();

        // Act
        var result = await useCase.ExecuteAsync(
            unknownId,
            "Non-Existing Company",
            "https://non-existing-company.com"
        );

        // Assert
        Assert.False(result);
        Assert.False(repository.SaveChangesCalled);
    }

    [Fact]
    public async Task ExecuteAsync_EmptyName_ThrowsAndDoesNotSave()
    {
        // Arrange
        var repository = new FakeCompanyRepository();

        var company = new Company("Microsoft");
        repository.Companies.Add(company);

        var useCase = new UpdateCompany(repository);

        // Act + Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => useCase.ExecuteAsync(
                company.Id,
                "",
                "https://example.com"
            )
        );

        Assert.Equal("Microsoft", company.Name);
        Assert.False(repository.SaveChangesCalled);
    }

}
