
using JobTracker.Application.Interfaces;
using JobTracker.Infrastructure.Persistence;
using JobTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobTracker.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		// Register SQL Server DbContext
		services.AddDbContext<JobTrackerDbContext>(
			options => options.UseSqlServer(
				configuration.GetConnectionString(
					"DefaultConnection")));

		// Register repository implementations
		services.AddScoped<ICompanyRepository, CompanyRepository>();

		return services;
	}
}
