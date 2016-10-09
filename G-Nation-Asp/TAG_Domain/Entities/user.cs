using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TAG_Domain.Entities
{
    public partial class User:IdentityUser
    {
        public int socialAuth { get; set; }

        public string HomeTown { get; set; }
        public System.DateTime? BirthDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    
        public User()
        {
            this.articles = new List<article>();
            this.articles1 = new List<article>();
            this.articles2 = new List<article>();
            this.articles3 = new List<article>();
            this.commentaires = new List<commentaire>();
            this.commentts = new List<commentt>();
            this.evenements = new List<evenement>();
            this.hardwares = new List<hardware>();
            this.panniers = new List<pannier>();
            this.participants = new List<participant>();
            this.participanttournaments = new List<participanttournament>();
            this.produits = new List<produit>();
            this.raitings = new List<raiting>();
        }

        public string DTYPE { get; set; }
        //public int idUser { get; set; }
        public string firstName { get; set; }
        public string image_link { get; set; }
            public string lastName { get; set; }
        //public string mail { get; set; }
        //public string password { get; set; }
       public string role { get; set; }
        public bool ban { get; set;}
        public string Secret { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        [MaxLength(100)]
        public string AllowedOrigin { get; set; }
        //public string username { get; set; }

        //public Nullable<int> team_id { get; set; }
        public virtual ICollection<article> articles { get; set; }
        public virtual ICollection<article> articles1 { get; set; }
        public virtual ICollection<article> articles2 { get; set; }
        public virtual ICollection<article> articles3 { get; set; }

        public virtual ICollection<commentaire> commentaires { get; set; }
        public virtual ICollection<commentt> commentts { get; set; }
        public virtual ICollection<evenement> evenements { get; set; }
        public virtual ICollection<hardware> hardwares { get; set; }
        public virtual ICollection<pannier> panniers { get; set; }
        public virtual ICollection<participant> participants { get; set; }
        public virtual ICollection<participanttournament> participanttournaments { get; set; }
        public virtual ICollection<produit> produits { get; set; }
        public virtual ICollection<raiting> raitings { get; set; }
    }
}
