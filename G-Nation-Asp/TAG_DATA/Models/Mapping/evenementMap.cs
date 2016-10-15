using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class evenementMap : EntityTypeConfiguration<evenement>
    {
        public evenementMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Evenement);

            // Properties
            this.Property(t => t.adresse)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.image_link)
                .HasMaxLength(255);

            this.Property(t => t.latitude)
                .HasMaxLength(255);

            this.Property(t => t.longitude)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("evenement");
            this.Property(t => t.id_Evenement).HasColumnName("id_Evenement");
            this.Property(t => t.adresse).HasColumnName("adresse");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.image_link).HasColumnName("image_link");
            this.Property(t => t.latitude).HasColumnName("latitude");
            this.Property(t => t.longitude).HasColumnName("longitude");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.nbrPlaces).HasColumnName("nbrPlaces");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.organizer_idUser).HasColumnName("organizer_idUser");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.evenements)
                .HasForeignKey(d => d.organizer_idUser);

        }
    }
}
