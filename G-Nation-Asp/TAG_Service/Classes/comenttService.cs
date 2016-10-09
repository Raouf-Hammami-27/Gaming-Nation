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
  public  class comenttService : Service<commentt>, IComments
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);

        public IEnumerable<commentt> GetCommentsByArticle(int id)
        {

            return utwk.GetRepository<commentt>().GetMany(t => t.article.idArticle == id);
        }

        public IEnumerable<commentt> GetCommentsByMonth(int month)
        {

            return utwk.GetRepository<commentt>().GetMany(t => t.date.Month == month && t.article.DTYPE=="game");
        }

        public IEnumerable<commentt> GetCommentsNewsByMonth(int month)
        {

            return utwk.GetRepository<commentt>().GetMany(t => t.date.Month == month && t.article.DTYPE == "news");
        }


        public IQueryable<DateTime> getDateOfComm()
        {
            return utwk.GetRepository<commentt>().getMonthcomm();


        }


      


    }
}
