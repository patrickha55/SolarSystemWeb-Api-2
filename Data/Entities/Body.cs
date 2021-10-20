using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Body : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0.01, double.MaxValue)]
        public double EarthMass { get; set; }
        [Range(0, double.MaxValue)]
        public double DistanceToTheSun { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int ComponentId { get; set; }
        public Component Component { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UpdatedAt < CreatedAt)
            {
                yield return new ValidationResult(
                    "Update time cannot be after created at time. Please try again.",
                    new[] { nameof(CreatedAt), nameof(UpdatedAt) });
            }
        }
    }
}
