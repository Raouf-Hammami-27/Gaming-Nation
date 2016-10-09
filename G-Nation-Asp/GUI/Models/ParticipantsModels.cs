using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAG_Domain.Entities;

namespace GUI.Models
{
    public class ParticipantsModels
    {
        public int idEvent { get; set; }
        public string idParticipant { get; set; }
        public Nullable<System.DateTime> date_limite { get; set; }
        public Nullable<int> idTournament { get; set; }
        public virtual User user { get; set; }
        public virtual tournament tournament { get; set; }
    }
}