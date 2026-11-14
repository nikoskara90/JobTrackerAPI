
namespace JobTracker.Application.Services;

public class RandomCompanyGenerator
{
    private static readonly string[] Names =
    {
        "NovaTech",
        "BlueOrbit",
        "CloudForge",
        "PixelWorks",
        "DataNest",
        "BrightLabs"
    };

    public (string Name, string Website) Generate()
    {
        var name = Names[Random.Shared.Next(Names.Length)];
        var suffix = Random.Shared.Next(1000, 9999);

        var generatedName = $"{name}-{suffix}";
        var website = $"https://{generatedName.ToLowerInvariant()}.example";

        return (generatedName, website);
    }
}
