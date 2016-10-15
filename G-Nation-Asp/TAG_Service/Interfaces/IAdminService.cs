using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;
using TAG_Service.Pattern;

namespace TAG_Service.Interfaces
{
    public interface IAdminService : IService<User>
    {
        int facebookStats();
        int googleStats();
        int membersStats();
        int vipStats();

        int imagesuploadedStats();


    }
}
