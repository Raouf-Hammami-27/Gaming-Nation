using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class gameViewModels : ArticleViewModels
    {

        public string category { get; set; }
        public Nullable<int> rating { get; set; }

        public gameViewModels() : base()
        {

        }

        public gameViewModels(string category, int rating)
        {
            this.category = category;
            this.rating = rating;
        }
    }


   



}


    

   

