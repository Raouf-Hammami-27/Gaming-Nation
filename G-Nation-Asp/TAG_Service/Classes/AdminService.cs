using TAG_DATA.Infrastructure;
using TAG_Domain.Entities;
using TAG_Service.Interfaces;
using TAG_Service.Pattern;

namespace TAG_Service.Classes
{
    public class AdminService : Service<User>, IAdminService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public int facebookStats()
        {

            return utwk.GetRepository<User>().FacebookStats();
        }
        public int googleStats()
        {

            return utwk.GetRepository<User>().GoogleStats();
        }
        public int membersStats()
        {

            return utwk.GetRepository<User>().countMembers();
        }
        public int vipStats()
        {

            return utwk.GetRepository<User>().countVips();
        }
        public int imagesuploadedStats()
        {

            return utwk.GetRepository<User>().countImages();
        }

    }
}
