using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class commentaire
    {
        public long idCommentaire { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public Nullable<int> idArticle { get; set; }
        public String idUser { get; set; }
        public virtual article article { get; set; }
        public virtual User user { get; set; }
    }
}
