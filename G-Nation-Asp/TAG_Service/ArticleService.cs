using TAG_DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;
using TAG_DATA.Repositories;

namespace TAG_Service
{
    public class ArticleService2 : IArticleService2
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddArticle(article a)
        {
            utwk.ArticleRepository.Add(a);
            utwk.Commit();
        }

        public List<article> getAllArticle()
        {
            return utwk.ArticleRepository.GetAll().ToList();
        }
    }
    public interface IArticleService2
    {
        void AddArticle(article a);
        List<article> getAllArticle();
    }
}
