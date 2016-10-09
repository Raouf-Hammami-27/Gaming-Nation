using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG_Domain.Entities;
using TAG_Service.Interfaces;
using TAG_Service.Pattern;

namespace TAG_Service.Classes
{
    public class ParticipantsService : Service<participanttournament>, IParticipantsService
    {
    }
}
