using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Domain.Entities
{
    public class member : User
    {
        public int? cashRecolted { get; set; }
        public int? ranking { get; set; }
        public int? trophies { get; set; }
        public virtual team team { get; set; }
        public int? team_id { get;set;}


        public member(int cashRecolted, int ranking, int trophies, team t, int idteam)
        {
            this.cashRecolted = cashRecolted;
            this.ranking = ranking;
            this.trophies = trophies;
            this.team_id = idteam;
        }

        public member()
        {
        }
    }
}
