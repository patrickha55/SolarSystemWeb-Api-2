using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DBInitializers
{
    public class ApplicationDBInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            IList<Region> regions = new List<Region>();

            regions.Add(new Region { Name = "Inner Solar System", DistanceToTheSun = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            regions.Add(new Region { Name = "Outer Solar System", DistanceToTheSun = 30.1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            regions.Add(new Region { Name = "Trans-Neptunian", DistanceToTheSun = 68, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            context.Regions.AddRange(regions);

            IList<Component> components = new List<Component>();

            components.Add(new Component { Name = "Star", Type = "G2 main-sequence star", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            components.Add(new Component { Name = "Rocky Planet", Type = "Rocky Planet", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            components.Add(new Component { Name = "Gas Planet", Type = "Gas Planet", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            context.Components.AddRange(components);

            IList<Body> bodies = new List<Body>();

            bodies.Add(new Body { Name = "Sun", EarthMass = 332900, DistanceToTheSun = 0, ComponentId = 1, RegionId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            bodies.Add(new Body { Name = "Earth", EarthMass = 1321, DistanceToTheSun = 1, ComponentId = 2, RegionId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            bodies.Add(new Body { Name = "Jupiter", EarthMass = 332900, DistanceToTheSun = 5.2, ComponentId = 3, RegionId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            context.Bodies.AddRange(bodies);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
