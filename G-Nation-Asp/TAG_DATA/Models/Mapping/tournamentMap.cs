using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class tournamentMap : EntityTypeConfiguration<tournament>
    {
        public tournamentMap()
        {
            // Primary Key
            this.HasKey(t => t.id_tournament);

            // Properties
            this.Property(t => t.adresse)
                .HasMaxLength(255);

            this.Property(t => t.broadcast_link)
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

            this.Property(t => t.url)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("tournament");
            this.Property(t => t.id_tournament).HasColumnName("id_tournament");
            this.Property(t => t.adresse).HasColumnName("adresse");
            this.Property(t => t.broadcast_link).HasColumnName("broadcast_link");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.image_link).HasColumnName("image_link");
            this.Property(t => t.latitude).HasColumnName("latitude");
            this.Property(t => t.longitude).HasColumnName("longitude");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.nbrPlaces).HasColumnName("nbrPlaces");
            this.Property(t => t.evenement_id_Evenement).HasColumnName("evenement_id_Evenement");
            this.Property(t => t.url).HasColumnName("url");


            // Relationships
            this.HasOptional(t => t.evenement)
                .WithMany(t => t.tournaments)
                .HasForeignKey(d => d.evenement_id_Evenement);

        }
    }
}
