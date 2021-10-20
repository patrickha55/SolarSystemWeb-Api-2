using Data.Configurations;
using Data.DBInitializers;
using Data.Entities;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Text;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=SolarSystemDB") 
        {
            Database.SetInitializer(new ApplicationDBInitializer());
        }
        public ApplicationContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public DbSet<Body> Bodies { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Component> Components { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BodyConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new ComponentConfiguration());
        }
    }
}
