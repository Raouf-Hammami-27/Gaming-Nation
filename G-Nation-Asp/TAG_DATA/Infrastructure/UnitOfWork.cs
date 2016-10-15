
using TAG_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Infrastructure;
using TAG_DATA.Repositories;

namespace TAG_DATA.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private tagContext dataContext;
       

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;

        }
        public void Commit()
        {
            dataContext.SaveChanges();
        }
        public void Dispose()
        {
            dataContext.Dispose();
        }

        public void CommitAsync()
        {
            dataContext.SaveChangesAsync();
        }

        public IRepositoryBaseAsync<T> GetRepository<T>() where T : class
        {
            IRepositoryBaseAsync<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }

        private ICommentRepository commentRepository;

        public ICommentRepository CommentRepository
        {
            get { return commentRepository = new CommentRepository(dbFactory); }
        }

        private IForumThRepository forumRepository;
        public IForumThRepository ForumThRepository
        {
            get { return forumRepository = new ForumThRepository(dbFactory); }
        }
        private IArticleRepository articleRepository;
        public IArticleRepository ArticleRepository
        {
            get { return articleRepository = new ArticleRepository(dbFactory); }
        }
        private IProduitRepository produitRepository;
        public IProduitRepository ProduitRepository
        {
            get { return produitRepository = new ProduitRepository(dbFactory); }
        }
        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get { return userRepository = new UserRepository(dbFactory); }
        }
        private IPannierRepository pannierRepository;
        public IPannierRepository PannierRepository
        {
            get { return pannierRepository = new PannierRepository(dbFactory); }
        }
        private IVipArticleRepository vipArticleRepository;
        public IVipArticleRepository VipArticleRepository
        {
            get { return vipArticleRepository = new VipArticleRepository(dbFactory); }
        }



    }
}
