namespace Data.Migrations
{
    using Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.
            IList<Region> regions = new List<Region>();

            regions.Add(new Region { Id = 1, Name = "Inner Solar System", DistanceToTheSun = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            regions.Add(new Region { Id = 2, Name = "Outer Solar System", DistanceToTheSun = 30.1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            regions.Add(new Region { Id = 3, Name = "Trans-Neptunian", DistanceToTheSun = 68, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            context.Regions.AddRange(regions);

            IList<Component> components = new List<Component>();

            components.Add(new Component { Id = 1, Name = "Star", Type = "G2 main-sequence star", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            components.Add(new Component { Id = 2, Name = "Rocky Planet", Type = "Rocky Planet", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            components.Add(new Component { Id = 3, Name = "Gas Planet", Type = "Gas Planet", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            context.Components.AddRange(components);

            IList<Body> bodies = new List<Body>();

            bodies.Add(new Body { Id = 1, Name = "Sun", EarthMass = 332900, DistanceToTheSun = 0, ComponentId = 1, RegionId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            bodies.Add(new Body { Id = 2, Name = "Earth", EarthMass = 1321, DistanceToTheSun = 1, ComponentId = 2, RegionId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            bodies.Add(new Body { Id = 3, Name = "Jupiter", EarthMass = 332900, DistanceToTheSun = 5.2, ComponentId = 3, RegionId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            context.Bodies.AddRange(bodies);
            context.SaveChanges();
            base.Seed(context);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
