using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_Domain.Entities
{
    public class vip:User
    {
        public vip(): base()
        {
        }
        public virtual ICollection<vipArticle> vipArticles { get; set; }
    }
}
