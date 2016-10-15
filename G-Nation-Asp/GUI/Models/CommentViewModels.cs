using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAG_Domain.Entities;

namespace GUI.Models
{
    public class CommentViewModels
    {

        public System.DateTime date { get; set; }
        public int idArticle { get; set; }
        public string idUser { get; set; }
        public string description { get; set; }
        public virtual article article { get; set; }
        public virtual User user { get; set; }
        public string name;
        

    }
}