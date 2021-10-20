using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DTOs
{
    public class BodyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Earth Mass")]
        public double EarthMass { get; set; }
        [Display(Name = "Distance to the Sun")]
        public string DistanceToTheSun { get; set; }
    }

    public class ManageBodyDTO
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [Range(minimum: 0, maximum: 98)]
        [Display(Name = "Earth Mass")]
        public double EarthMass { get; set; }
        [Required]
        [Range(0.1, double.MaxValue)]
        [Display(Name = "Distance to the Sun")]
        public double DistanceToTheSun { get; set; }
    }
}
