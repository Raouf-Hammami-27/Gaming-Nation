using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class pannier
    {
        public long idPannier { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<long> idProduit { get; set; }
        public string idUser { get; set; }
        public virtual produit produit { get; set; }
        public virtual User user { get; set; }
    }
}
