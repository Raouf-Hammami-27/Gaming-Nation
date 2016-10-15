


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
    public class ForumThRepository : RepositoryBase<forumthread>, IForumThRepository
    {
        public ForumThRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<forumthread> GetMany(Expression<Func<forumthread, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
    public interface IForumThRepository : IRepository<forumthread>
    {

    }
}
