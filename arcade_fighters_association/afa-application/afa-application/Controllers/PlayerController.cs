using Microsoft.AspNetCore.Mvc;
using afa_application.Models;
using afa_application.DAO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace afa_application.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController : ControllerBase
    {
        private IPlayerDao playerDao;
        public PlayerController(IPlayerDao dao)
        {
            this.playerDao = dao;
        
        }
        [HttpGet()]
        
        public ActionResult<List<Player>> GetPlayers()
        {
            List<Player> players = new List<Player>();
            List<Player>alltheplayers = playerDao.GetPlayers();
            if (alltheplayers == null)
            {
                return NotFound();
            }
            else if (alltheplayers != null)
            {
                foreach (Player player in alltheplayers)
                {
                    players.Add(player);
                }
                return players;
            }

            return StatusCode(500);    
                    
        }
        
        
    }
}
