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
    public class PannierRepository : RepositoryBase<pannier>, IPannierRepository
    {
        public PannierRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<pannier> GetMany(Expression<Func<pannier, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
    public interface IPannierRepository : IRepository<pannier>
    {

    }
}

