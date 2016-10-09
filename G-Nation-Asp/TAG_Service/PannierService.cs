
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Models;

using TAG_Domain.Entities;
using TAG_DATA.Infrastructure;
namespace TAG_Service
{
    public class PannierService : IPannierService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void Add(pannier p)
        {
            utwk.PannierRepository.Add(p);
            utwk.Commit();
        }

        public void Delete(pannier p)
        {
            utwk.PannierRepository.Delete(p);
            utwk.Commit();

        }

        public List<pannier> getAllPannier()
        {
            return utwk.PannierRepository.GetAll().ToList();
        }
        public virtual IEnumerable<pannier> GetMany(Expression<Func<pannier, bool>> filter = null, Expression<Func<pannier, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.GetRepository<pannier>().GetMany(filter, orderBy);
        }

        public pannier getById(int id)
        {
            return utwk.PannierRepository.GetById(id);
        }

        public void Update(pannier p)
        {
            utwk.PannierRepository.Update(p);
            utwk.Commit();
        }

        public async Task<List<pannier>> FindAllAsync(Expression<Func<pannier, bool>> match)
        {
            return await utwk.GetRepository<pannier>().FindAllAsync(match);
        }
        public virtual async Task<List<pannier>> GetAllAsync()
        {
            //return await _repository.GetAllAsync();
            return await utwk.GetRepository<pannier>().GetAllAsync();
        }
        public int CountPannier(int idUser)
        {



            var hi = utwk.GetRepository<pannier>().GetMany(h => h.idUser.Equals(idUser));
            int nbrhiii = hi.Count<pannier>();
            return nbrhiii;
        }

        public virtual async Task<pannier> FindAsync(Expression<Func<pannier, bool>> match)
        {
            //return await _repository.FindAsync(match);
            return await utwk.GetRepository<pannier>().FindAsync(match);
        }

    }
    public interface IPannierService
    {
        void Add(pannier p);
        List<pannier> getAllPannier();
        pannier getById(int id);
        void Delete(pannier p);
        void Update(pannier p);
       
        Task<List<pannier>> FindAllAsync(Expression<Func<pannier, bool>> match);
        Task<List<pannier>> GetAllAsync();
        int CountPannier(int idUser);
        Task<pannier> FindAsync(Expression<Func<pannier, bool>> match);
        IEnumerable<pannier> GetMany(Expression<Func<pannier, bool>> where = null, Expression<Func<pannier, bool>> orderBy = null);
    }
}
