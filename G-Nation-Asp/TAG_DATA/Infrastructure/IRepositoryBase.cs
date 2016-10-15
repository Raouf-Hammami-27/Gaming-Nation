using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_DATA.Infrastructure
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T id);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> orderBy = null);
        T GetByRole(string role);

        void DeleteById(int id);
        void UpdateById(int id);

        void Detach(T entity);

        int countMembers();
        int countVips();
        int countImages();
        int GoogleStats();
        int FacebookStats();


        List<game> GetAllGames();
        List<game> getBestRankedgames();
        IQueryable<DateTime> getMonthcomm();
        List<User> getUsersComments();
        List<game> Ratedgames();
        List<news> GetMostCommentedNews();
    }
}
