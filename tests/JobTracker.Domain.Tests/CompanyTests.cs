
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



}
