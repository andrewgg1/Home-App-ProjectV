using HomeUIWithMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeUIWithMAUI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Thermostat> Thermostats { get; set; }
        public DbSet<SmartLock> SmartLocks { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SecurityAlarm> SecurityAlarms { get; set; }
        public DbSet<SecurityCamera> SecurityCameras { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<Vacuum> Vacuums { get; set; }
        public DbSet<Dehumidifier> Dehumidifiers { get; set; }
        public DbSet<Oven> Ovens { get; set; }
        public DbSet<Fridge> Fridges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=localdatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure any model-specific constraints or relationships here if necessary
            base.OnModelCreating(modelBuilder);
        }
    }
}
