using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TAG_Domain.Entities;
namespace GUI.Models
{
    public class EvenementModels
    {
        public EvenementModels()
        {
            this.tournaments = new List<tournament>();
            this.participants = new List<participant>();
        }

        public int id_Evenement { get; set; }

        [Display(Name = "Adress")]
        public string adresse { get; set; }

        [Display(Name = "Date")]
        public Nullable<System.DateTime> date { get; set; }

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

        [Display(Name = "Category")]
        public string type { get; set; }

        [Display(Name = "Organizer")]
        public string organizer_idUser { get; set; }

        public virtual User user { get; set; }
        public virtual ICollection<tournament> tournaments { get; set; }
        public virtual ICollection<participant> participants { get; set; }
    
}
}