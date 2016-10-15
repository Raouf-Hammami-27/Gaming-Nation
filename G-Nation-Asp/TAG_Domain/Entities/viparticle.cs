using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_Domain.Entities
{
    public class vipArticle:article
    {
        public vipArticle(): base()
        {
        }
        private string category { get; set; }
        private vip vipp { get; set; }
    }
}
