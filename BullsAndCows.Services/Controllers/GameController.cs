using BullsAndCows.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BullsAndCows.Models;
using BullsAndCows.Services.Models;

namespace BullsAndCows.Services.Controllers
{
    [Authorize]
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private IBullsAndCowsData data;

        public GameController(IBullsAndCowsData data)
           // :base(data)
        {
            this.data = data;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(string name, string password = null)
        {
            string currUser = this.User.Identity.GetUserId();
            var game = new Game(name)
            {
                FirstPlayerId = currUser
            };

            if (password != null)
            {
                game.Password = password;
            }

            this.data.Games.Add(game);
            this.data.SaveChanges();
            return Ok(game.Id.ToString());
        }

        [HttpPost]
        [Route("join")]
        public IHttpActionResult Join()
        {
            var id = this.User.Identity.GetUserId();
            var pendingGame = this.data.Games
                .All()
                .Where(g => g.FirstPlayerId != id && g.Status == Status.WaitingPlayer)
                .FirstOrDefault();

            if (pendingGame == null)
            {
                return NotFound();
            }

            pendingGame.SecondPlayerId = id;
            pendingGame.Status = Status.FirstPlayerTurn;
            pendingGame.Started = DateTime.Now;
            this.data.SaveChanges();
            return Ok(pendingGame.Id);
        }

        [HttpGet]
        [Route("status")]
        public IHttpActionResult GameStatus(string gameId)
        {
            var id = this.User.Identity.GetUserId();
            var game = this.data.Games.All()
                .Where(g => g.Id.ToString() == gameId)
                .Select(g => new { FirstPlayerId = g.FirstPlayerId, SecondPlayerId = g.SecondPlayerId })
                .FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            if (game.FirstPlayerId != id &&  game.SecondPlayerId != id)
            {
                return BadRequest("Not your game!");
            }

            var info = this.data.Games.All()
                .Where(g => g.Id.ToString() == gameId)
                .Select(g => new GameInfoModel()
                {
                    FirstPlayerName = g.FirstPlayer.UserName,
                    SecondPlayerName = g.SecondPlayer.UserName,
                    GameStatus = g.Status,
                    Id = g.Id
                }).FirstOrDefault();

            return Ok(info);
        }
    }
}
