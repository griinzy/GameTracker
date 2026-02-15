using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GameTracker.Services;
using GameTracker.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameTracker.Data;

namespace GameTracker.Web.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = new SelectList(await _gameService.GetGenresAsync(), "Id", "Name");
            ViewBag.Developers = new SelectList(await _gameService.GetDevelopersAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameCreateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                //return RedirectToAction("Login", "Account");
            }

            await _gameService.AddGameAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateGenre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                //return RedirectToAction("Login", "Account");
            }

            await _gameService.AddGenreAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateDeveloper()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeveloper(CreateDeveloperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                //return RedirectToAction("Login", "Account");
            }

            await _gameService.AddDeveloperAsync(model);
            return RedirectToAction("Index");
        }
    }
}
