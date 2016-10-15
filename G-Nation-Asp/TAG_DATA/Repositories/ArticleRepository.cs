using TAG_DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

using System.Linq.Expressions;

namespace TAG_DATA.Repositories
{
    public class ArticleRepository : RepositoryBase<article>, IArticleRepository
    {
        public ArticleRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<article> GetMany(Expression<Func<article, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
    public interface IArticleRepository : IRepository<article>
    {

    }
}
