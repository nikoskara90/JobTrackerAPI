
namespace JobTracker.Domain.Entities;

public class Company
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Website { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Company(string name, string? website = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Company name cannot be empty.",
                nameof(name));
        }

        Id = Guid.NewGuid();
        Name = name.Trim();
        Website = website;
        CreatedAt = DateTime.UtcNow;
    }

    public void Rename(string newName){

        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(
                "Company name cannot be empty.",
                nameof(newName));
        
        Name = newName.Trim();
    }
}
