using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ComponentConfiguration : EntityTypeConfiguration<Component>
    {
        public ComponentConfiguration()
        {
            ToTable("Components");

            Property(c => c.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Name).HasMaxLength(255).IsRequired();
            Property(c => c.Type).HasMaxLength(100).IsRequired();

            Property(b => b.CreatedAt).HasColumnName("Created At").HasColumnType("datetime2").IsRequired();
            Property(b => b.UpdatedAt).HasColumnName("Updated At").HasColumnType("datetime2").IsRequired();
        }
    }
}
