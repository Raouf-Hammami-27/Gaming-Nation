using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Infrastructure;

namespace TAG_Service.Pattern
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Private Fields
        // private readonly IRepositoryBaseAsync<TEntity> _repository;
        IUnitOfWork utwk;
        #endregion Private Fields

        #region Constructor

        private IDatabaseFactory dbf = null;
        protected IUnitOfWork ut = null;
        protected Service()
        {
            dbf = new DatabaseFactory();
            utwk = new UnitOfWork(dbf);
            //  this.utwk = utwk;
        }
        #endregion Constructor



        public virtual void Add(TEntity entity)
        {
            ////_repository.Add(entity);
            utwk.GetRepository<TEntity>().Add(entity);
                utwk.Commit();
        }

        public virtual void Update(TEntity entity)
        {
            //_repository.Update(entity);
            utwk.GetRepository<TEntity>().Update(entity);
            utwk.Commit();

        }

        public virtual void Delete(TEntity entity)
        {
            //   _repository.Delete(entity);
            utwk.GetRepository<TEntity>().Delete(entity);
            utwk.Commit();

        }
        public virtual void Delete(string id)
        {
            //   _repository.Delete(entity);
            TEntity t = utwk.GetRepository<TEntity>().GetById(id);
                Delete(t);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            // _repository.Delete(where);
            utwk.GetRepository<TEntity>().Delete(where);
            utwk.Commit();

        }

        public virtual TEntity GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.GetRepository<TEntity>().GetById(id);
        }

        public virtual TEntity GetById(string id)
        {
            //return _repository.GetById(id);
            return utwk.GetRepository<TEntity>().GetById(id);
        }
        public virtual TEntity GetByRole(string role)
        {
            //return _repository.GetById(id);
            return utwk.GetRepository<TEntity>().GetByRole(role);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.GetRepository<TEntity>().GetMany(filter, orderBy);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            //return _repository.Get(where);
            return utwk.GetRepository<TEntity>().Get(where);
        }

        public virtual async Task<int> CountAsync()
        {
            //return await _repository.CountAsync();
            return await utwk.GetRepository<TEntity>().CountAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            //return await _repository.GetAllAsync();
            return await utwk.GetRepository<TEntity>().GetAllAsync();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            //return await _repository.FindAsync(match);
            return await utwk.GetRepository<TEntity>().FindAsync(match);
        }

        public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            // return await _repository.FindAllAsync(match);
            return await utwk.GetRepository<TEntity>().FindAllAsync(match);
        }



        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CommitAsync()
        {
            try
            {
                utwk.CommitAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            utwk.Dispose();
        }
    }
}
