using SolarSystem.Data.Entities;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Text;

namespace SolarSystem.Data
{
    public class ApplicationContext : DbContext
    {
        protected ApplicationContext() : base("SolarSystemDB") { }
        public ApplicationContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public DbSet<Body> Bodies { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Component> Components { get; set; }
    }
}
