using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Domain.Entities
{
   public class game : article
    {


        public string category { get; set; }
        public Nullable<int> rating { get; set; }

        public game(): base()
        {
        }
        public game(string category, int rating)
        {
            this.category = category;
            this.rating = rating;
        }
       

    }
}
