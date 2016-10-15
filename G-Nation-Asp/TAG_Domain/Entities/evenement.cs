using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class evenement
    {
        public evenement()
        {
            this.tournaments = new List<tournament>();
            this.participants = new List<participant>();
        }

        public int id_Evenement { get; set; }
        public string adresse { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public string image_link { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string name { get; set; }
        public int nbrPlaces { get; set; }
        public string type { get; set; }
        public string organizer_idUser { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<tournament> tournaments { get; set; }
        public virtual ICollection<participant> participants { get; set; }
    }
}
