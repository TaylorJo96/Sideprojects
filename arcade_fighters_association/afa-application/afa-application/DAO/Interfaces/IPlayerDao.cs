using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using afa_application.Models;



namespace afa_application.DAO
{
    public interface IPlayerDao
    {
        Player GetPlayer(int playerId);
        public List<Player> GetPlayers();

    }
}
