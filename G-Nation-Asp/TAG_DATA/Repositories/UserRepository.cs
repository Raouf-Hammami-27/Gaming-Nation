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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<User> GetMany(Expression<Func<User, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
    public interface IUserRepository : IRepository<User>
    {

    }
}

