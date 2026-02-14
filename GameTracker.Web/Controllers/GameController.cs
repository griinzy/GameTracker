using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GameTracker.Services;

namespace GameTracker.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllGamesAsync();
            return View(games);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }
    }
}
