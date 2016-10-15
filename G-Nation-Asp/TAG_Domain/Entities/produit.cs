using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class produit
    {
        public produit()
        {
            this.panniers = new List<pannier>();
        }

        public long idProduit { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public string image_link { get; set; }
        public string name { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<int> quantite { get; set; }
        public string idUser { get; set; }
        public virtual ICollection<pannier> panniers { get; set; }
        public virtual User user { get; set; }
    }
}
