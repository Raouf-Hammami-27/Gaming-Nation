using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;
namespace TAG_DATA.Models.Mapping
{
    public class broadcastMap : EntityTypeConfiguration<broadcast>
    {
        public broadcastMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.link)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("broadcast");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.link).HasColumnName("link");
            this.Property(t => t.title).HasColumnName("title");
        }
    }
}
