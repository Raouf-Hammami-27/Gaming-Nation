using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class hardwareMap : EntityTypeConfiguration<hardware>
    {
        public hardwareMap()
        {
            // Primary Key
            this.HasKey(t => t.id_hardware);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.reference)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("hardware");
            this.Property(t => t.id_hardware).HasColumnName("id_hardware");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.reference).HasColumnName("reference");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.admin_idUser).HasColumnName("admin_idUser");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.hardwares)
                .HasForeignKey(d => d.admin_idUser);

        }
    }
}
