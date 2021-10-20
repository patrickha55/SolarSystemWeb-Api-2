using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configurations
{
    public class RegionConfiguration : EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            ToTable("Regions");

            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(r => r.Name).HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            Property(r => r.DistanceToTheSun).HasColumnName("Distance To The Sun (AU)").IsRequired();

            Property(b => b.CreatedAt).HasColumnName("Created At").HasColumnType("datetime2").IsRequired();
            Property(b => b.UpdatedAt).HasColumnName("Updated At").HasColumnType("datetime2").IsRequired();
        }
    }
}
