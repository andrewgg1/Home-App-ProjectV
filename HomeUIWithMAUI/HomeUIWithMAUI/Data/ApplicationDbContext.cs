using HomeUIWithMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeUIWithMAUI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Thermostat> Thermostats { get; set; }
        public DbSet<SmartLock> SmartLocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "localdatabase.db");
                Directory.CreateDirectory(Path.GetDirectoryName(dbPath)); // Ensure the directory exists
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Thermostat>(entity =>
            {
                entity.HasKey(t => t.DeviceId);

                entity.Property(t => t.CurrentTemperature).IsRequired();
                entity.Property(t => t.CurrentState).HasConversion<string>().IsRequired();
            });

            modelBuilder.Entity<SmartLock>(entity =>
            {
                entity.HasKey(sl => sl.DeviceId);

                entity.Property(sl => sl.CurrentState).HasConversion<string>().IsRequired();
                entity.Property(sl => sl.IsLocked).IsRequired();
            });
        }
    }
}
