using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_DATA.Models.Mapping
{
    class memberMap : EntityTypeConfiguration<member>
    {
        public memberMap()
        {


            this.Property(t => t.cashRecolted).HasColumnName("cashRecolted");
            this.Property(t => t.ranking).HasColumnName("ranking");
            this.Property(t => t.trophies).HasColumnName("trophies");
                        this.Property(t => t.team_id).HasColumnName("team_id");

            // Relationships
            this.HasOptional(t => t.team)
                .WithMany(t => t.members)
                .HasForeignKey(d => d.team_id);
        }

        }
    }
