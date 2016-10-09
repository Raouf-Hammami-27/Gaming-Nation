using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class produitMap : EntityTypeConfiguration<produit>
    {
        public produitMap()
        {
            // Primary Key
            this.HasKey(t => t.idProduit);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.image_link)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("produit");
            this.Property(t => t.idProduit).HasColumnName("idProduit");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.image_link).HasColumnName("image_link");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.quantite).HasColumnName("quantite");
            this.Property(t => t.idUser).HasColumnName("idUser");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.produits)
                .HasForeignKey(d => d.idUser);

        }
    }
}
