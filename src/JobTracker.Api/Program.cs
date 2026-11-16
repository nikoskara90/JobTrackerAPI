using JobTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using JobTracker.Application.Interfaces;
using JobTracker.Infrastructure.Repositories;
using JobTracker.Application.Services;
using JobTracker.Application.UseCases.Companies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CreateCompany>();
builder.Services.AddSingleton<RandomCompanyGenerator>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddControllers();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<CreateCompany>();
builder.Services.AddScoped<GetCompanyById>();
builder.Services.AddScoped<GetAllCompanies>();
builder.Services.AddSingleton<RandomCompanyGenerator>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<JobTrackerDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString(
            "DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
