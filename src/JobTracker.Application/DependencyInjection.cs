
using Microsoft.Extensions.DependencyInjection;
using JobTracker.Application.Services;
using JobTracker.Application.Companies.UseCases;

namespace JobTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<CreateCompany>();
        services.AddScoped<GetCompanyById>();
        services.AddScoped<GetAllCompanies>();
        services.AddScoped<UpdateCompany>();
        services.AddScoped<DeleteCompany>();

        services.AddSingleton<RandomCompanyGenerator>();

        return services;
    }
}
