using TAG_Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Infrastructure;
using TAG_Domain.Entities;
using TAG_Service.Interfaces;

namespace TAG_Service.Classes
{
 public   class ratingService : Service<raiting>, IratingService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);

        public IEnumerable<raiting> GetNbrateMonth(int month)
        {

            return utwk.GetRepository<raiting>().GetMany(t => t.date.Month == month);
        }




    }
}
