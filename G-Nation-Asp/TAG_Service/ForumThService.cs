using TAG_DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Models;
using TAG_Domain.Entities;

namespace TAG_Service
{
    public class ForumThService : IForumThService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddForumTh(forumthread f)
        {
            utwk.ForumThRepository.Add(f);
            utwk.Commit();
        }
        

        public void Delete(forumthread f)
        {
            utwk.ForumThRepository.Delete(f);
            utwk.Commit();

        }

        public List<forumthread> getAllForumThs()
        {
            return utwk.ForumThRepository.GetAll().ToList();
        }
        public virtual IEnumerable<forumthread> GetMany(Expression<Func<forumthread, bool>> filter = null, Expression<Func<forumthread, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.GetRepository<forumthread>().GetMany(filter, orderBy);
        }

        public forumthread getById(int id)
        {
            return utwk.ForumThRepository.GetById(id);
        }

        public void Update(forumthread f)
        {
            utwk.ForumThRepository.Update(f);
            utwk.Commit();
        }

        public async Task<List<forumthread>> FindAllAsync(Expression<Func<forumthread, bool>> match)
        {
            return await utwk.GetRepository<forumthread>().FindAllAsync(match);
        }
        public virtual async Task<List<forumthread>> GetAllAsync()
        {
            //return await _repository.GetAllAsync();
            return await utwk.GetRepository<forumthread>().GetAllAsync();
        }
        public int CountForumTh(String idUser)
        {



            var hi = utwk.GetRepository<forumthread>().GetMany(h => h.idUser.Equals(idUser));
            int nbrhiii = hi.Count<forumthread>();
            return nbrhiii;
        }
    } 
    public interface IForumThService
    {
        void AddForumTh(forumthread f);
        List<forumthread> getAllForumThs();
        forumthread getById(int id);
        void Delete(forumthread f);
        void Update(forumthread f);
        Task<List<forumthread>> FindAllAsync(Expression<Func<forumthread, bool>> match);
        Task<List<forumthread>>GetAllAsync();
        int CountForumTh(string idUser);
        IEnumerable<forumthread> GetMany(Expression<Func<forumthread, bool>> where = null, Expression<Func<forumthread, bool>> orderBy = null);
    }
}
