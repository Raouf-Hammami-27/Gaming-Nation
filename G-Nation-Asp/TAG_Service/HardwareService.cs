using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Infrastructure;
using TAG_Domain.Entities;

namespace TAG_Service
{
   public class HardwareService : IHardwareService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddHardware(hardware a)
        {
            utwk.GetRepository<hardware>().Add(a);
            utwk.Commit();
        }

        public List<hardware> getAllHardwares()
        {
            return utwk.GetRepository<hardware>().GetAll().ToList();
        }
    }
}
