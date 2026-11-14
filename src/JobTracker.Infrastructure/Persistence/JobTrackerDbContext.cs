
using JobTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Infrastructure.Persistence;

public class JobTrackerDbContext : DbContext
{
    public JobTrackerDbContext(
        DbContextOptions<JobTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<JobApplication> JobApplications
        => Set<JobApplication>();

protected override void OnModelCreating(
    ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Company>(entity =>
    {
        entity.HasKey(c => c.Id);

        entity.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);
    });

    modelBuilder.Entity<JobApplication>(entity =>
    {
        entity.HasKey(a => a.Id);

        entity.Property(a => a.Position)
            .IsRequired()
            .HasMaxLength(200);

        entity.HasOne<Company>()
            .WithMany()
            .HasForeignKey(a => a.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    });
}
}
