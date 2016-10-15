using System;
using TAG_DATA.Repositories;

namespace TAG_DATA.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBaseAsync<T> GetRepository<T>() where T : class;
        void CommitAsync();
        void Commit();
        IForumThRepository ForumThRepository { get; }
        IVipArticleRepository VipArticleRepository { get; }
        IPannierRepository PannierRepository { get; }
        IProduitRepository ProduitRepository { get; }
        ICommentRepository CommentRepository { get; }
        IArticleRepository ArticleRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
