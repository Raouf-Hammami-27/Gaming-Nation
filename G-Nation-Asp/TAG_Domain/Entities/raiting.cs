using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class raiting
    {
        public int idArticle { get; set; }
        public string idUser { get; set; }
        public Nullable<int> rate { get; set; }
        public virtual article article { get; set; }
        public virtual User user { get; set; }
        public System.DateTime date { get; set; }


    }
}
