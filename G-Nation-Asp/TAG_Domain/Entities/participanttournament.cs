using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class participanttournament
    {
        public int idEvent { get; set; }
        public string idParticipant { get; set; }
        public Nullable<System.DateTime> date_limite { get; set; }
        public Nullable<int> idTournament { get; set; }
        public virtual User user { get; set; }
        public virtual tournament tournament { get; set; }
    }
}
