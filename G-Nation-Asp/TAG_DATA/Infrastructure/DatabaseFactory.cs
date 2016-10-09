using TAG_DATA.Infrastructure;
using TAG_DATA.Models;

namespace TAG_DATA.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private tagContext dataContext;
        public tagContext DataContext
        {
            get { return dataContext; }
        }

        public DatabaseFactory()
        {
            dataContext = new tagContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }

    }
}
