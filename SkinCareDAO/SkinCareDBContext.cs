using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SkinCareBussinessObject;
using System.IO;

/*
```
dotnet ef migrations add YOUR_MIGRATION_NAME
```
dotnet ef database update
```
 */

namespace SkinCareDAO
{
    public class SkinCareDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Try to find appsettings.json in current directory or parent directories
                string baseDir = Directory.GetCurrentDirectory();
                string settingsPath = Path.Combine(baseDir, "appsettings.json");

                if (!File.Exists(settingsPath))
                {
                    // Look in UI project
                    var solutionDir = Directory.GetParent(baseDir)?.FullName;
                    if (solutionDir != null)
                    {
                        var uiSettingsPath = Path.Combine(solutionDir, "SkinCareUI", "appsettings.json");
                        if (File.Exists(uiSettingsPath))
                        {
                            settingsPath = uiSettingsPath;
                            baseDir = Path.GetDirectoryName(uiSettingsPath);
                        }
                    }
                }

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(baseDir)
                    .AddJsonFile(Path.GetFileName(settingsPath))
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}