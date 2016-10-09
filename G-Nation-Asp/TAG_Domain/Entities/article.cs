using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TAG_Domain.Entities
{
    public partial class article
    {
        public article()
        {
            this.commentts = new List<commentt>();
            this.commentaires = new List<commentaire>();
            this.raitings = new List<raiting>();
        }

        public string DTYPE { get; set; }
        [Key]
        public int idArticle { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public string link_img { get; set; }
        public string link_imgg { get; set; }
        public string name { get; set; }

       




        public string adminn_idUser { get; set; }
        public string member_idUser { get; set; }
        public byte[] media { get; set; }
        public string idUser { get; set; }
        public string idVip { get; set; }
        public virtual ICollection<commentt> commentts { get; set; }
        public virtual ICollection<commentaire> commentaires { get; set; }
        public virtual User user { get; set; }
        public virtual User user1 { get; set; }
        public virtual User user2 { get; set; }
        public virtual User user3 { get; set; }
        public virtual ICollection<raiting> raitings { get; set; }
    }
}
