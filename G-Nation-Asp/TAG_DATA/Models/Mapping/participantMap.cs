using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class participantMap : EntityTypeConfiguration<participant>
    {
        public participantMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idEvent, t.idParticipant });

            // Properties
            this.Property(t => t.idEvent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idParticipant)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("participants");
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.idParticipant).HasColumnName("idParticipant");
            this.Property(t => t.date_Limite).HasColumnName("date_Limite");
            this.Property(t => t.idEvenement).HasColumnName("idEvenement");

            // Relationships
            this.HasOptional(t => t.evenement)
                .WithMany(t => t.participants)
                .HasForeignKey(d => d.idEvenement);
            this.HasRequired(t => t.user)
                .WithMany(t => t.participants)
                .HasForeignKey(d => d.idParticipant);

        }
    }
}
