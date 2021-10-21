﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class RegionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DistanceToTheSun { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<BodyDTO> Bodies { get; set; }
    }

    public class ManageRegionDTO
    {
        [StringLength(255,MinimumLength = 1)]
        public string Name { get; set; }
        [Range(0.1, double.MaxValue)]
        [Display(Name = "Distance To The Sun (AU)")]
        public double DistanceToTheSun { get; set; }
    }
}
