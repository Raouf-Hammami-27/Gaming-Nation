
using TAG_DATA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Infrastructure;
using TAG_Domain.Entities;

namespace TAG_DATA.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBaseAsync<T> where T : class
    {
        private tagContext dataContext;

        protected tagContext DataContext
        {
            get { return dataContext = databaseFactory.DataContext; }
        }

        private IDbSet<T> dbset;
        IDatabaseFactory databaseFactory;

       public RepositoryBase(IDatabaseFactory dbFactory)
        {
            this.databaseFactory = dbFactory;
            dbset = DataContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity); dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects) dbset.Remove(obj);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual T GetByRole(string role)
        {
            return dbset.Find(role);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> orderBy = null)
        {
            IQueryable<T> Query = dbset;
            if (where != null)
            {
                Query = Query.Where(where);
            }
            if (orderBy != null)
            {
                Query = Query.OrderBy(orderBy);
            }
            return Query;
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
        public async Task<int> CountAsync()
        {
            return await dbset.CountAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await dbset.SingleOrDefaultAsync(match);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await dbset.Where(match).ToListAsync();
        }
        public void DeleteById(int id)
        {
            var obj = dbset.Find(id);
            dbset.Remove(obj);
        }

        public void UpdateById(int id)
        {
            var obj = dbset.Find(id);
            dbset.Attach(obj);
            dataContext.Entry(obj).State = EntityState.Modified;
        }

        public void Detach(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Detached;
        }
        public int countMembers()
        {
            return dataContext.Users.Where(p => p.role == "Member").Count();
        }
        public int countVips()
        {
            return dataContext.Users.Where(p => p.role == "Vip").Count();
        }

        public int countImages()
        {
            return dataContext.Users.Count();
        }
        public int GoogleStats()
        {
            return dataContext.Users.Where(u => u.socialAuth == 1).Count();
        }
        public int FacebookStats()
        {
            return dataContext.Users.Where(u => u.socialAuth == 2).Count();
        }



        public virtual List<game> GetAllGames()
        {

            return (List<game>)DataContext.articles.OfType<game>().OrderByDescending(p => p.commentts.Count()).Where(p => p.commentts.Count != 0).ToList();


        }


        public virtual List<news> GetMostCommentedNews()
        {

            return (List<news>)DataContext.articles.OfType<news>().OrderByDescending(p => p.commentts.Count()).Where(p => p.commentts.Count != 0).ToList();


        }




        public virtual List<User> getUsersComments()
        {
            return DataContext.Users.OrderByDescending(u => u.commentts.Count()).Where(p => p.commentts.Count != 0).ToList();


        }


        public virtual List<game> getBestRankedgames()
        {
            return (List<game>)DataContext.articles.OfType<game>().OrderByDescending(p => p.rating).ToList();


        }

        public virtual List<game> Ratedgames()
        {
            return (List<game>)DataContext.articles.OfType<game>().OrderByDescending(p => p.rating).Where(r => r.rating != 0).ToList();


        }



        public IQueryable<DateTime> getMonthcomm()
        {
            var req = (from t in DataContext.commentts
                       select t.date);
            return req;


        }
    }
}
