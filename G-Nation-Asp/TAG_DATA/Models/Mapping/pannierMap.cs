using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;
namespace TAG_DATA.Models.Mapping
{
    public class pannierMap : EntityTypeConfiguration<pannier>
    {
        public pannierMap()
        {
            // Primary Key
            this.HasKey(t => t.idPannier);

            // Properties
            // Table & Column Mappings
            this.ToTable("pannier");
            this.Property(t => t.idPannier).HasColumnName("idPannier");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.idProduit).HasColumnName("idProduit");
            this.Property(t => t.idUser).HasColumnName("idUser");

            // Relationships
            this.HasOptional(t => t.produit)
                .WithMany(t => t.panniers)
                .HasForeignKey(d => d.idProduit);
            this.HasOptional(t => t.user)
                .WithMany(t => t.panniers)
                .HasForeignKey(d => d.idUser);

        }
    }
}
