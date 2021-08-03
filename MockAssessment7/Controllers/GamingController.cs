using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockAssessment7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingController : ControllerBase
    {
        GameDB DB = new GameDB();

        [HttpGet("players")]
        public List<Player> GetPlayers()
        {
            return DB.Players.ToList();
        }

        [HttpGet("classes")]
        public List<PlayerClass> GetClasses()
        {
            return DB.PlayerClasses.ToList();
        }

        [HttpGet("PlayersMinLevel/{level}")]
        public List<Player> GetPlayersAboveLevel(int level)
        {
            return DB.Players.Where(x => x.Level >= level).ToList();
        }

        [HttpGet("PlayersSortLevel")]
        public List<Player> GetSortedPlayers()
        {
            return DB.Players.OrderBy(x=>x.Level).Reverse().ToList();
        }

        [HttpGet("PlayersOfClass/{playerClass}")]
        public List<Player> GetFromClass(string playerClass)
        {
            return DB.Players.Where(x => x.CurrentClass.Name.ToLower() == playerClass.ToLower()).ToList();
        }

        [HttpGet("PlayersOfType/{playerType}")]
        public List<Player> GetFromType(string playerType)
        {
            return DB.Players.Where(x => x.CurrentClass.Type.ToLower() == playerType.ToLower()).ToList();
        }

        [HttpGet("AllPlayedClasses")]
        public List<PlayerClass> GetPlayedClasses()
        {
            List<PlayerClass> playedClasses = new List<PlayerClass>();
            foreach(PlayerClass _class in DB.PlayerClasses)
            {
                if (DB.Players.Exists(x => x.CurrentClass == _class))
                {
                    playedClasses.Add(_class);
                }
            }
            return playedClasses;
        }
    }
}
