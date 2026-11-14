
using JobTracker.Domain.Entities;
using JobTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using JobTracker.Application.Services;


var databasePath = Path.GetFullPath(
    "src/JobTracker.Api/jobtracker.db");

var options = new DbContextOptionsBuilder<JobTrackerDbContext>()
    .UseSqlite($"Data Source={databasePath}")
    .Options;

Console.WriteLine(
    $"Working directory: {Directory.GetCurrentDirectory()}");

using (var context = new JobTrackerDbContext(options))
{
    Console.WriteLine(
        $"Database path: {context.Database.GetDbConnection().DataSource}");

    Console.WriteLine(
        $"Database exists: {await context.Database.CanConnectAsync()}");
}

// STEP 1: Save a company
using (var context = new JobTrackerDbContext(options))
{
    var company = new Company("Microsoft");

    context.Companies.Add(company);

    await context.SaveChangesAsync();

    Console.WriteLine($"Saved company: {company.Name}");
}

// STEP 2: Retrieve it using a new DbContext
using (var context = new JobTrackerDbContext(options))
{
    var company = await context.Companies
        .AsNoTracking()
        .FirstOrDefaultAsync(c => c.Name == "Microsoft");

    if (company is not null)
    {
        Console.WriteLine($"Found company: {company.Name}");
        Console.WriteLine($"Company ID: {company.Id}");
    }
    else
    {
        Console.WriteLine("Company not found!");
    }
}

// STEP 3: Save a JobApplication
using (var context = new JobTrackerDbContext(options))
{
    var company = await context.Companies
        .FirstAsync(c => c.Name == "Microsoft");

    var application = new JobApplication(
        company.Id,
        "Backend Developer");

    context.JobApplications.Add(application);
    await context.SaveChangesAsync();

    Console.WriteLine("Job application saved!");
}


// STEP 4: Retrieve a JobApplication
using (var context = new JobTrackerDbContext(options))
{
    var application = await context.JobApplications
        .AsNoTracking()
        .FirstOrDefaultAsync(a => a.Position == "Backend Developer");

    if (application is not null)
    {
        Console.WriteLine($"Position: {application.Position}");
        Console.WriteLine($"Status: {application.Status}");

        var company = await context.Companies
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == application.CompanyId);

        if (company is not null)
        {
            Console.WriteLine($"Company: {company.Name}");
        }
    }
    else
    {
        Console.WriteLine("Job application not found!");
    }

    // STEP 5: Generate a random company
    var generator = new RandomCompanyGenerator();

    var (name, website) = generator.Generate();

    Console.WriteLine($"Random company: {name}");
    Console.WriteLine($"Website: {website}");
}

