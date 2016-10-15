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
    public class ServiceGames : Service<game>, IGamesService
    {

        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        
        public List<game> getMostCommented()
        {
            return utwk.GetRepository<article>().GetAllGames();

        }

        public List<game> getBestRanked()
        {
            return utwk.GetRepository<game>().getBestRankedgames();
        }

       public List<game> RatedGames()
        {

            return utwk.GetRepository<game>().Ratedgames();


        }



    }
}
