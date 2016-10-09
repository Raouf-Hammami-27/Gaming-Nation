using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class participant
    {
        public int idEvent { get; set; }
        public string idParticipant { get; set; }
        public Nullable<System.DateTime> date_Limite { get; set; }
        public Nullable<int> idEvenement { get; set; }
        public virtual evenement evenement { get; set; }
        public virtual User user { get; set; }
    }
}
