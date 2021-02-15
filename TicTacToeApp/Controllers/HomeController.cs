using System;
using Microsoft.AspNetCore.Mvc;
using TicTacToeApp.Models;

namespace TicTacToeApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("new-game")]
        public IActionResult NewGame()
        {
            var gameId = GameManager.New();

            return RedirectToAction(nameof(Game), new {gameId});
        }

        [Route("game/{gameId}")]
        public IActionResult Game(Guid gameId)
        {
            var game = GameManager.Find(gameId);

            if (game == null)
                return RedirectToAction(nameof(Index));

            return View(game);
        }
    }
}