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
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllGamesAsync();
            return View(games);
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

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var game = await _gameService.GetGameDetailsByIdAsync(id);
            if(game == null)
            {
                return RedirectToAction("Index");
            }

            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetGameForEditByIdAsync(id);
            if (game == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Genres = new SelectList(await _gameService.GetGenresAsync(), "Id", "Name");
            ViewBag.Developers = new SelectList(await _gameService.GetDevelopersAsync(), "Id", "Name");
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameEditViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            await _gameService.EditGameAsync(model);
            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetGameForDeletionByIdAsync(id);
            if (game == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Genres = new SelectList(await _gameService.GetGenresAsync(), "Id", "Name");
            ViewBag.Developers = new SelectList(await _gameService.GetDevelopersAsync(), "Id", "Name");
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _gameService.DeleteGameAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Save(int id)
        {
            string? userId = GetUserId();

            await _gameService.SaveGameAsync(id, userId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SavedGames()
        {
            string? userId = GetUserId();
            var games = await _gameService.GetSavedGamesAsync(userId);
            return View(games);
        }
    }
}
