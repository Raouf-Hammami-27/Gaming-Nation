using TAG_Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_Service.Interfaces
{
  public  interface IComments : IService<commentt>
    {
       IEnumerable<commentt> GetCommentsByArticle(int id);
        IQueryable<DateTime> getDateOfComm();
        IEnumerable<commentt> GetCommentsByMonth(int month);
        IEnumerable<commentt> GetCommentsNewsByMonth(int month);
    }



}
