
using JobTracker.Domain.Entities;
using JobTracker.Domain.Enums;

namespace JobTracker.Domain.Tests;

public class JobApplicationTests
{
    [Fact]
    public void Constructor_WithValidData_SetsAppliedStatus()
    {
        // Arrange
        var company = new Company("Microsoft");

        // Act
        var application = new JobApplication(
            company.Id,
            "Backend Developer");

        // Assert
        Assert.Equal(
            ApplicationStatus.Applied,
            application.Status);
    }


    [Fact]
    public void ChangeStatus_WithValidStatus_UpdatesStatus()
    {
        // Arrange
        var company = new Company("Microsoft");

        var application = new JobApplication(
            company.Id,
            "Backend Developer");

        // Act
        application.ChangeStatus(
            ApplicationStatus.Interviewing);

        // Assert
        Assert.Equal(
            ApplicationStatus.Interviewing,
            application.Status);
    }


    [Fact]
    public void ChangeStatus_WithInvalidStatus_ThrowsException()
    {
        // Arrange
        var company = new Company("Microsoft");

        var application = new JobApplication(
            company.Id,
            "Backend Developer");

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            application.ChangeStatus((ApplicationStatus)999));

        Assert.Equal(
            ApplicationStatus.Applied,
            application.Status);
    }

}
