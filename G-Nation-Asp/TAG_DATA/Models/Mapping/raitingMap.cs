using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class raitingMap : EntityTypeConfiguration<raiting>
    {
        public raitingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idArticle, t.idUser });

            // Properties
            this.Property(t => t.idArticle)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("raiting");
            this.Property(t => t.idArticle).HasColumnName("idArticle");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.rate).HasColumnName("rate");
            this.Property(t => t.date).HasColumnName("date");


            // Relationships
            this.HasRequired(t => t.article)
                .WithMany(t => t.raitings)
                .HasForeignKey(d => d.idArticle);
            this.HasRequired(t => t.user)
                .WithMany(t => t.raitings)
                .HasForeignKey(d => d.idUser);

        }
    }
}
