using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class commenttMap : EntityTypeConfiguration<commentt>
    {
        public commenttMap()
        {
            // Primary Key
            this.HasKey(t => new { t.date, t.idArticle, t.idUser });

            // Properties
            this.Property(t => t.idArticle)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("commentt");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.idArticle).HasColumnName("idArticle");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.description).HasColumnName("description");

            // Relationships
            this.HasRequired(t => t.article)
                .WithMany(t => t.commentts)
                .HasForeignKey(d => d.idArticle);
            this.HasRequired(t => t.user)
                .WithMany(t => t.commentts)
                .HasForeignKey(d => d.idUser);

        }
    }
}
