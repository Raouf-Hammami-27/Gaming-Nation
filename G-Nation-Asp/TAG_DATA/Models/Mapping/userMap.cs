using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TAG_Domain.Entities;
namespace TAG_DATA.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<User>
    {
        public userMap()
        {
            // Primary Key
            //this.HasKey(t => t.idUser);

            // Properties
            //this.Property(t => t.DTYPE)
            //    .IsRequired()
            //    .HasMaxLength(31);

            //this.Property(t => t.firstName)
            //    .HasMaxLength(255);

            this.Property(t => t.image_link)
               .HasMaxLength(255);

            //this.Property(t => t.lastName)
            //    .HasMaxLength(255);

            //this.Property(t => t.mail)
            //    .HasMaxLength(255);

            //this.Property(t => t.password)
            //    .HasMaxLength(255);

            this.Property(t => t.role)
                .HasMaxLength(255);


            //this.Property(t => t.username)
            //    .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            //this.Property(t => t.idUser).HasColumnName("idUser");
            // this.Property(t => t.firstName).HasColumnName("firstName");
             this.Property(t => t.image_link).HasColumnName("image_link");
            // this.Property(t => t.lastName).HasColumnName("lastName");
            // this.Property(t => t.mail).HasColumnName("mail");
            // this.Property(t => t.password).HasColumnName("password");
             this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.ban).HasColumnName("ban");
            this.Property(t => t.socialAuth).HasColumnName("socialAuth");



            // this.Property(t => t.username).HasColumnName("username");

            //// inheritance
            Map<member>(c => { c.Requires("IsMember").HasValue(1); });
            Map<vip>(b => { b.Requires("IsVip").HasValue(1); });

        }
    }
}
