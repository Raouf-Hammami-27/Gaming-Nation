using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TAG_DATA.Models.Mapping;
using TAG_Domain.Entities;


namespace TAG_DATA.Models
{
    public partial class tagContext : IdentityDbContext<User>
    {
        static tagContext()
        {
            Database.SetInitializer<tagContext>(null);
        }

        public tagContext()
            : base("Name=tagContext")
        {
        }
        public static tagContext Create()
        {

            return new tagContext();
        }

        public DbSet<article> articles { get; set; }
        public DbSet<broadcast> broadcasts { get; set; }
        public DbSet<commentaire> commentaires { get; set; }
        public DbSet<commentt> commentts { get; set; }
        public DbSet<evenement> evenements { get; set; }
        public DbSet<hardware> hardwares { get; set; }
        public DbSet<pannier> panniers { get; set; }
        public DbSet<participant> participants { get; set; }
        public DbSet<participanttournament> participanttournaments { get; set; }
        public DbSet<produit> produits { get; set; }
        public DbSet<raiting> raitings { get; set; }
        public DbSet<team> teams { get; set; }
        public DbSet<tournament> tournaments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new articleMap());
            modelBuilder.Configurations.Add(new broadcastMap());
            modelBuilder.Configurations.Add(new commentaireMap());
            modelBuilder.Configurations.Add(new commenttMap());
            modelBuilder.Configurations.Add(new evenementMap());
            modelBuilder.Configurations.Add(new hardwareMap());
            modelBuilder.Configurations.Add(new pannierMap());
            modelBuilder.Configurations.Add(new participantMap());
            modelBuilder.Configurations.Add(new participanttournamentMap());
            modelBuilder.Configurations.Add(new produitMap());
            modelBuilder.Configurations.Add(new raitingMap());
            modelBuilder.Configurations.Add(new teamMap());
            modelBuilder.Configurations.Add(new tournamentMap());
            modelBuilder.Configurations.Add(new userMap());
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }
    }
}
