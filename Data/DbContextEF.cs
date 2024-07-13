using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
  class DbContextEF : DbContext
  {

    private IConfiguration _config;

    public DbContextEF(IConfiguration config)
    {
      _config = config;
    }
    public DbSet<Computer>? Computer {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      if (!options.IsConfigured)
      {
          options.UseSqlServer(
          _config.GetConnectionString("DefaultConnection"),
          options => options.EnableRetryOnFailure()
          );
      }
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<Computer>()
            .HasKey("ComputerId");
        }
    }
}