using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double TotalMass { get; set; }
    }
}
