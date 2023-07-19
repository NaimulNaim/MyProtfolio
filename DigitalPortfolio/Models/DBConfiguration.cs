using DigitalPortfolio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalPortfolio.Models
{
    public class DBConfiguration : DbContext
    {
        public DBConfiguration(DbContextOptions<DBConfiguration> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CategoryInfo> CategoryInfo { get; set; }

        public DbSet<ContactMessage> ContactMessage { get; set; }

        public DbSet<Content> Content { get; set; }

        public DbSet<EducationInfo> EducationInfo { get; set; }

        public DbSet<ExperienceInfo> ExperienceInfo { get; set; }

        public DbSet<Entities.FileInfo> FileInfo { get; set; }

        public DbSet<PersonalInfo> PersonalInfo { get; set; }

        public DbSet<PortfolioInfo> PortfolioInfo { get; set; }

        public DbSet<ServiceInfo> ServiceInfo { get; set; }

        public DbSet<SocialMediaInfo> SocialMediaInfo { get; set; }






    }
}
