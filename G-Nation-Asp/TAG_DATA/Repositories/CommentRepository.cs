


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
    public class CommentRepository : RepositoryBase<commentaire>, ICommentRepository
    {
        public CommentRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<commentaire> GetMany(Expression<Func<commentaire, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
    public interface ICommentRepository : IRepository<commentaire>
    {

    }
}
