using HomeUIWithMAUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeUIWithMAUI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Thermostat> Thermostats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=localdatabase.db");
        }
    }
}
