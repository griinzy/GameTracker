using GameTracker.Services;
using GameTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Web.Controllers
{
    public class LibraryController : BaseController
    {
        private readonly GameService _gameService;

        public LibraryController(GameService gameService)
        {
            _gameService = gameService;
        }


        [Authorize]
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var games = await _gameService.GetSavedGamesAsync(GetUserId());
            return View(games);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(int id)
        {
            await _gameService.SaveGameAsync(id, GetUserId());
            return RedirectToAction("Index", "Game");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditSavedGame(int id)
        {
            var savedGame = await _gameService.GetSavedGameByIdAsync(id, GetUserId());
            return View(savedGame);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditSavedGame(GameSaveViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _gameService.EditSavedGameAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteSavedGame(int id)
        {
            var savedGame = await _gameService.GetSavedGameByIdAsync(id, GetUserId());
            if (savedGame == null)
            {
                return RedirectToAction("Index");
            }
            return View(savedGame);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmDeleteSavedGame(int id)
        {
            await _gameService.DeleteSavedGame(id);
            return RedirectToAction("Index");
        }
    }
}
