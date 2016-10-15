


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TAG_Domain.Entities;

using TAG_DATA.Infrastructure;
using System.Linq.Expressions;

namespace TAG_DATA.Repositories
{
    public class ProduitRepository : RepositoryBase<produit>, IProduitRepository
    {
      

       

        public ProduitRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<produit> GetMany(Expression<Func<produit, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
    public interface IProduitRepository : IRepository<produit>
    {

    }
}
