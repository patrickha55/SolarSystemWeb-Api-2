using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Body
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double EarthMass { get; set; }
        public double DistanceToTheSun { get; set; }
    }
}
