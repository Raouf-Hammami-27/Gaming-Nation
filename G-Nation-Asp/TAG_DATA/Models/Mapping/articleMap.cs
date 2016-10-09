using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    public class articleMap : EntityTypeConfiguration<article>
    {
        public articleMap()
        {
            // Primary Key
            this.HasKey(t => t.idArticle);

            // Properties
            this.Property(t => t.DTYPE)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.description)
                .HasMaxLength(5000);

            this.Property(t => t.link_img)
                .HasMaxLength(255);

            this.Property(t => t.link_imgg)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);
           
            // Table & Column Mappings
            this.ToTable("article");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            this.Property(t => t.idArticle).HasColumnName("idArticle");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.link_img).HasColumnName("link_img");
            this.Property(t => t.link_imgg).HasColumnName("link_imgg");
            this.Property(t => t.name).HasColumnName("name");  
            this.Property(t => t.adminn_idUser).HasColumnName("adminn_idUser");
            this.Property(t => t.member_idUser).HasColumnName("member_idUser");
            this.Property(t => t.media).HasColumnName("media");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.idVip).HasColumnName("idVip");
           


           




            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.articles)
                .HasForeignKey(d => d.member_idUser);
            this.HasOptional(t => t.user1)
                .WithMany(t => t.articles1)
                .HasForeignKey(d => d.idUser);
            this.HasOptional(t => t.user2)
                .WithMany(t => t.articles2)
                .HasForeignKey(d => d.adminn_idUser);
            this.HasOptional(t => t.user3)
                .WithMany(t => t.articles3)
                .HasForeignKey(d => d.idVip);


            // heritage
            Map<game>(c => { c.Requires("IsGame").HasValue(1); });
            Map<news>(b => { b.Requires("IsNews").HasValue(0); });

            Map<vipArticle>(a => { a.Requires("IsVipArticle").HasValue(3); });
            Map<forumthread>(a => { a.Requires("IsForum").HasValue(2); });




        }
    }
}
