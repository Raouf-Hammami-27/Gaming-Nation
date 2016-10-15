using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;
namespace TAG_DATA.Models.Mapping
{
    public class commentaireMap : EntityTypeConfiguration<commentaire>
    {
        public commentaireMap()
        {
            // Primary Key
            this.HasKey(t => t.idCommentaire);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("commentaire");
            this.Property(t => t.idCommentaire).HasColumnName("idCommentaire");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.idArticle).HasColumnName("idArticle");
           // this.Property(t => t.idUser).HasColumnName("idUser");

            // Relationships
            this.HasOptional(t => t.article)
                .WithMany(t => t.commentaires)
                .HasForeignKey(d => d.idArticle);
            this.HasOptional(t => t.user)
                .WithMany(t => t.commentaires)
                .HasForeignKey(d => d.idUser);

        }
    }
}
