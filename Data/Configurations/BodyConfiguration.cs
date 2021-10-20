using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class BodyConfiguration : EntityTypeConfiguration<Body>
    {
        public BodyConfiguration()
        {
            ToTable("Bodies");

            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(b => b.Name).HasMaxLength(255).HasColumnType("nvarchar").IsRequired();
            Property(b => b.EarthMass).HasColumnName("Earth Mass (AU)").IsRequired();
            Property(b => b.DistanceToTheSun).HasColumnName("Distance To The Sun (AU)").IsRequired();
            Property(b => b.ComponentId).HasColumnName("Component Id").IsRequired();
            Property(b => b.RegionId).HasColumnName("Region Id").IsRequired();

            Property(b => b.CreatedAt).HasColumnName("Created At").HasColumnType("datetime2").IsRequired();
            Property(b => b.UpdatedAt).HasColumnName("Updated At").HasColumnType("datetime2").IsRequired();

            HasRequired(b => b.Component).WithMany(c => c.Bodies).HasForeignKey(b => b.ComponentId).WillCascadeOnDelete(true);
            HasRequired(b => b.Region).WithMany(c => c.Bodies).HasForeignKey(b => b.RegionId).WillCascadeOnDelete(true);
        }
    }
}
