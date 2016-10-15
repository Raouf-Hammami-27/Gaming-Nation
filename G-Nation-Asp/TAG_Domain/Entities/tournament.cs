using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class tournament
    {
        public tournament()
        {
            this.participanttournaments = new List<participanttournament>();
        }

        public int id_tournament { get; set; }
        public string adresse { get; set; }
        public string broadcast_link { get; set; }
        public string description { get; set; }
        public string image_link { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string name { get; set; }
        public int nbrPlaces { get; set; }
        public Nullable<int> evenement_id_Evenement { get; set; }
        public virtual evenement evenement { get; set; }
        public virtual ICollection<participanttournament> participanttournaments { get; set; }
        public string url { get; set; }

    }
}
