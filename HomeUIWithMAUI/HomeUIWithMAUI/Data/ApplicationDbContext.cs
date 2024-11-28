using HomeUIWithMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeUIWithMAUI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Thermostat> Thermostats { get; set; }
        public DbSet<SmartLock> SmartLocks { get; set; }
        //public DbSet<SecurityAlarm> SecurityAlarms { get; set; }
        //public DbSet<Sensor> Sensors { get; set; }
        //public DbSet<SecurityCamera> SecurityCameras { get; set; }
        //public DbSet<Tracker> Trackers { get; set; }
        //public DbSet<Dehumidifier> Dehumidifiers { get; set; }
        //public DbSet<Fridge> Fridges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=localdatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Thermostat>(entity =>
            {
                // Configure primary key
                entity.HasKey(t => t.DeviceId);

                // Map properties
                entity.Property(t => t.DeviceId)
                      .IsRequired();

                entity.Property(t => t.CurrentState)
                      .HasConversion<string>() // Store enum as string
                      .IsRequired();

                entity.Property(t => t.CurrentTemperature)
                      .IsRequired();

                // Constructor binding
                entity.HasAnnotation(
                    "Relational:ConstructorBinding",
                    new Func<double, State, Thermostat>((currentTemp, state) =>
                        new Thermostat(currentTemp, state))
                );
            });

            modelBuilder.Entity<SmartLock>(entity =>
            {
                // Configure primary key
                entity.HasKey(sl => sl.DeviceId);

                // Map properties
                entity.Property(sl => sl.DeviceId)
                      .IsRequired();

                entity.Property(sl => sl.CurrentState)
                      .HasConversion<string>() // Store enum as string
                      .IsRequired();

                entity.Property(sl => sl.IsLocked)
                      .IsRequired();

                // Constructor binding
                entity.HasAnnotation(
                    "Relational:ConstructorBinding",
                    new Func<int, State, bool, SmartLock>((deviceId, state, defaultLockState) =>
                        new SmartLock(deviceId, state, defaultLockState))
                );
            });


        }



    }
}
