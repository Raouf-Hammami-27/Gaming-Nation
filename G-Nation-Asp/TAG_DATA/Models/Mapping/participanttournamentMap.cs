using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class participanttournamentMap : EntityTypeConfiguration<participanttournament>
    {
        public participanttournamentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idEvent, t.idParticipant });

            // Properties
            this.Property(t => t.idEvent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idParticipant)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("participanttournament");
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.idParticipant).HasColumnName("idParticipant");
            this.Property(t => t.date_limite).HasColumnName("date_limite");
            this.Property(t => t.idTournament).HasColumnName("idTournament");

            // Relationships
            this.HasRequired(t => t.user)
                .WithMany(t => t.participanttournaments)
                .HasForeignKey(d => d.idParticipant);
            this.HasOptional(t => t.tournament)
                .WithMany(t => t.participanttournaments)
                .HasForeignKey(d => d.idTournament);

        }
    }
}
