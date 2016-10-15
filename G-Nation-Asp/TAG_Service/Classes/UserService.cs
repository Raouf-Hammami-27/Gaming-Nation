using TAG_Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Infrastructure;
using TAG_Domain.Entities;
using TAG_Service.Interfaces;

namespace TAG_Service.Classes
{
    public class UserService : Service<User>, IUsersService
    {

        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);

        public List<User> getUsersComments()
        {
            return utwk.GetRepository<User>().getUsersComments();

        }

    }


}
