using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystem.Data.Entities
{
    public class Body
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double EarthMass { get; set; }
        public string DistanceToTheSun { get; set; }
    }
}
