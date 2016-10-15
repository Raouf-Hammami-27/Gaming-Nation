using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TAG_Domain.Entities;

namespace GUI.Models
{
    public class TournamentModels
    {
        public TournamentModels()
        {
            this.participanttournaments = new List<participanttournament>();
        }

        public int id_tournament { get; set; }

        [Display(Name = "Adress")]
        public string adresse { get; set; }

        [Display(Name = "Broadcast Link")]
        public string broadcast_link { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Image")]
        public string image_link { get; set; }
        [Display(Name = "Latitude")]
        public string latitude { get; set; }
        [Display(Name = "Longitude")]
        public string longitude { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Total Participants")]
        public int nbrPlaces { get; set; }

        [Display(Name = "Related Event")]
        public Nullable<int> evenement_id_Evenement { get; set; }
        public virtual evenement evenement { get; set; }
        public virtual ICollection<participanttournament> participanttournaments { get; set; }

        [Display(Name = "Challonge url")]
        public string url { get; set; }
    }
}
