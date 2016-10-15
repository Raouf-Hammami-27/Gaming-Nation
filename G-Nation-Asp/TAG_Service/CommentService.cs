using TAG_DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_Service
{
    public class CommentService:ICommentService
    {
        
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void Add(commentaire c)
        {
            utwk.CommentRepository.Add(c);
            utwk.Commit();
        }

        public int CountCmt(int idCmt)
        {
            var hi = utwk.GetRepository<commentaire>().GetMany(h => h.idCommentaire == idCmt);
            int nbrhiii = hi.Count<commentaire>();
            return nbrhiii;
        }

        public void Delete(commentaire c)
        {
            utwk.CommentRepository.Delete(c);
            utwk.Commit();
        }

        public async Task<List<commentaire>> FindAllAsync(Expression<Func<commentaire, bool>> match)
        {
            return await utwk.GetRepository<commentaire>().FindAllAsync(match);
        }

        public async Task<List<commentaire>> GetAllAsync()
        {
            //return await _repository.GetAllAsync();
            return await utwk.GetRepository<commentaire>().GetAllAsync();
        }

        public List<commentaire> getAllComment()
        {
            return utwk.CommentRepository.GetAll().ToList();
        }

        public commentaire getById(int id)
        {
            return utwk.CommentRepository.GetById(id);
        }

        public virtual IEnumerable<commentaire> GetMany(Expression<Func<commentaire, bool>> filter = null, Expression<Func<commentaire, bool>> orderBy = null)
        {
            return utwk.GetRepository<commentaire>().GetMany(filter, orderBy);

        }
    }
    public interface ICommentService
    {
        void Add(commentaire c);
        List<commentaire> getAllComment();
        Task<List<commentaire>> FindAllAsync(Expression<Func<commentaire, bool>> match);
        Task<List<commentaire>> GetAllAsync();
        int CountCmt(int idCmt);
        commentaire getById(int id);
        void Delete(commentaire c);
        IEnumerable<commentaire> GetMany(Expression<Func<commentaire, bool>> where = null, Expression<Func<commentaire, bool>> orderBy = null);
    }

}

