using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class gameCommViewModels : ArticleViewModels
    {
        public string category { get; set; }
        public Nullable<int> rating { get; set; }

        public gameCommViewModels() : base()
        {

        }

        public gameCommViewModels(string category, int rating)
        {
            this.category = category;
            this.rating = rating;
        }
    }
}