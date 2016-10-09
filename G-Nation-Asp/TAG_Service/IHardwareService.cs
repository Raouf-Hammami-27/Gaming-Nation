using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;

namespace TAG_Service
{
    public interface IHardwareService
    {
         void AddHardware(hardware a);
         List<hardware> getAllHardwares();

    }
}
