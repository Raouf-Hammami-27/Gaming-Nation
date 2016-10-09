using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;
using TAG_DATA.Infrastructure;

namespace TAG_Service
{
    public class VipArticleService : IVipArticleService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void Add(vipArticle v)
        {
            utwk.VipArticleRepository.Add(v);
            utwk.Commit();
        }


        public void Delete(vipArticle v)
        {
            utwk.VipArticleRepository.Delete(v);
            utwk.Commit();

        }

        public List<vipArticle> getAllviparticle()
        {
            return utwk.VipArticleRepository.GetAll().ToList();
        }
        public virtual IEnumerable<vipArticle> GetMany(Expression<Func<vipArticle, bool>> filter = null, Expression<Func<vipArticle, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.GetRepository<vipArticle>().GetMany(filter, orderBy);
        }

        public vipArticle getById(int id)
        {
            return utwk.VipArticleRepository.GetById(id);
        }

        public void Update(vipArticle v)
        {
            utwk.VipArticleRepository.Update(v);
            utwk.Commit();
        }

        public async Task<List<vipArticle>> FindAllAsync(Expression<Func<vipArticle, bool>> match)
        {
            return await utwk.GetRepository<vipArticle>().FindAllAsync(match);
        }
        public virtual async Task<List<vipArticle>> GetAllAsync()
        {
            //return await _repository.GetAllAsync();
            return await utwk.GetRepository<vipArticle>().GetAllAsync();
        }
        public int Countviparticle(int idUser)
        {



            var hi = utwk.GetRepository<vipArticle>().GetMany(h => h.idUser.Equals(idUser));
            int nbrhiii = hi.Count<vipArticle>();
            return nbrhiii;
        }
    }

    

    public interface IVipArticleService
    {
        void Add(vipArticle v);
        List<vipArticle> getAllviparticle();
        vipArticle getById(int id);
        void Delete(vipArticle v);
        void Update(vipArticle v);
        Task<List<vipArticle>> FindAllAsync(Expression<Func<vipArticle, bool>> match);
        Task<List<vipArticle>> GetAllAsync();
        int Countviparticle(int idUser);
        IEnumerable<vipArticle> GetMany(Expression<Func<vipArticle, bool>> where = null, Expression<Func<vipArticle, bool>> orderBy = null);
    }
}
