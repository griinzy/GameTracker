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

            if (string.IsNullOrEmpty(GetUserId()))
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

            if (string.IsNullOrEmpty(GetUserId()))
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

            if (string.IsNullOrEmpty(GetUserId()))
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
            await _gameService.SaveGameAsync(id, GetUserId());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SavedGames()
        {
            var games = await _gameService.GetSavedGamesAsync(GetUserId());
            return View(games);
        }

        [HttpGet]
        public async Task<IActionResult> EditSavedGame(int id)
        {
            var savedGame = await _gameService.GetSavedGameByIdAsync(id, GetUserId());
            return View(savedGame);
        }

        [HttpPost]
        public async Task<IActionResult> EditSavedGame(GameSaveViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _gameService.EditSavedGameAsync(model);
            return RedirectToAction("SavedGames");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSavedGame(int id)
        {
            var savedGame = await _gameService.GetSavedGameByIdAsync(id, GetUserId());
            if (savedGame == null)
            {
                return RedirectToAction("SavedGames");
            }
            return View(savedGame);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDeleteSavedGame(int id)
        {
            await _gameService.DeleteSavedGame(id);
            return RedirectToAction("SavedGames");
        }
    }
}
