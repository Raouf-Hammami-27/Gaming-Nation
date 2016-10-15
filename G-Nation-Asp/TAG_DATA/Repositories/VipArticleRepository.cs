using TAG_DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_DATA.Repositories
{
    public class VipArticleRepository : RepositoryBase<vipArticle>, IVipArticleRepository
    {
        public VipArticleRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        
        public IEnumerable<vipArticle> GetMany(Expression<Func<vipArticle, bool>> where)
        {
            throw new NotImplementedException();
        }

        
    }
    public interface IVipArticleRepository : IRepository<vipArticle>
    {

    }
}
