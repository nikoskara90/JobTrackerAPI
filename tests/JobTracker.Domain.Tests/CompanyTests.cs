
using JobTracker.Domain.Entities;

namespace JobTracker.Domain.Tests;

public class CompanyTests
{
    [Fact]
    public void Constructor_WithValidName_CreatesCompany()
    {
        // Arrange
        string name = "Microsoft";

        // Act
        var company = new Company(name);

        // Assert
        Assert.Equal("Microsoft", company.Name);
        Assert.NotEqual(Guid.Empty, company.Id);
    }

    [Fact]
    public void Constructor_WithEmptyName_ThrowsException()
    {
        // Arrange
        string invalidName = "";

        // Act & Assert
        Assert.Throws<ArgumentException>(
            () => new Company(invalidName));
    }


    [Fact]
    public void Rename_WithValidName_UpdatesCompanyName()
    {
        // Arrange
        var company = new Company("Microsoft");

        // Act
        company.Rename("Google");

        // Assert
        Assert.Equal("Google", company.Name);
    }

    [Fact]
    public void Rename_WithWhitespace_TrimsCompanyName()
    {
        // Arrange
        var company = new Company("Microsoft");

        // Act
        company.Rename("   Google   ");

        // Assert
        Assert.Equal("Google", company.Name);
    }

    [Fact]
    public void UpdateWebsite_ValidWebsite_UpdatesWebsite()
    {
        // Arrange
        var company = new Company("Microsoft");

        // Act
        company.UpdateWebsite("https://microsoft.com");

        // Assert
        Assert.Equal(
            "https://microsoft.com",
            company.Website
        );
    }

    [Fact]
    public void UpdateWebsite_Null_ClearsWebsite()
    {
        // Arrange
        var company = new Company(
            "Microsoft", 
            "https://microsoft.com"
            );

        // Act
        company.UpdateWebsite(null);

        // Assert
        Assert.Null(company.Website);
    }

}
