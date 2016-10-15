using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class commentt
    { 

        public System.DateTime date { get; set; }
        public int idArticle { get; set; }
        public string idUser { get; set; }
        public string description { get; set; }
        public virtual article article { get; set; }
        public virtual User user { get; set; }
    }
}
