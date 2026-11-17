
using JobTracker.Application.Tests.Fakes;
using JobTracker.Application.UseCases.Companies;

namespace JobTracker.Application.Tests.UseCases;

public class CreateCompanyTests
{
    [Fact]
    public async Task ExecuteAsync_ValidCompany_SavesCompany()
    {
        // Arrange
        var repository = new FakeCompanyRepository();

        var useCase = new CreateCompany(repository);

        // Act
        var companyId = await useCase.ExecuteAsync(
            "Microsoft",
            "https://microsoft.com"
        );

        // Assert
        Assert.Single(repository.Companies);

        var savedCompany = repository.Companies[0];

        Assert.Equal("Microsoft", savedCompany.Name);
        Assert.Equal("https://microsoft.com", savedCompany.Website);
        Assert.Equal(companyId, savedCompany.Id);
        Assert.True(repository.SaveChangesCalled);
    }

    [Fact]
    public async Task ExecuteAsync_EmptyName_ThrowsException()
    {
        // Arrange
        var repository = new FakeCompanyRepository();
        var useCase = new CreateCompany(repository);

        // Act + Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => useCase.ExecuteAsync("", null)
        );

        // Then verify:
        Assert.Empty(repository.Companies);
        Assert.False(repository.SaveChangesCalled);
    }

}
