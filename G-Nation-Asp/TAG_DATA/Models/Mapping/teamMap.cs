using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;
namespace TAG_DATA.Models.Mapping
{
    public class teamMap : EntityTypeConfiguration<team>
    {
        public teamMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("team");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
        }
    }
}
