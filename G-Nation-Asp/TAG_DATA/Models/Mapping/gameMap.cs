using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
  public  class gameMap : EntityTypeConfiguration<game>
    {
        public gameMap()
        {



            this.Property(t => t.category)
              .HasMaxLength(255);


            // Table & Column Mappings
            this.Property(t => t.category).HasColumnName("category");
            this.Property(t => t.rating).HasColumnName("rating");




        }



    }
}
