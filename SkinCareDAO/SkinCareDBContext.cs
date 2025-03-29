using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SkinCareBussinessObject;
using System.IO;

/*
```
dotnet ef migrations add YOUR_MIGRATION_NAME (can not use existed migration's name)
```
dotnet ef database update
```
 */

namespace SkinCareDAO
{
    public class SkinCareDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }
        public DbSet<AssessmentResponse> AssessmentResponses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentHistory> AppointmentHistories { get; set; }
        public DbSet<CenterLocation> CenterLocations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ResponseServiceMapping> ResponseServiceMappings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServicePromotion> ServicePromotions { get; set; }
        public DbSet<ServiceRecommendation> ServiceRecommendations { get; set; }
        public DbSet<ServiceToCategory> ServiceToCategories { get; set; }
        public DbSet<SkinAssessment> SkinAssessments { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<TherapistExpertise> TherapistExpertises { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<WorkingSchedule> WorkingSchedules { get; set; }
        public DbSet<TimeOffRequest> TimeOffRequests { get; set; }

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