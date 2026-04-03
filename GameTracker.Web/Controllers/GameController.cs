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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = new SelectList(await _gameService.GetGenresAsync(), "Id", "Name");
            ViewBag.Developers = new SelectList(await _gameService.GetDevelopersAsync(), "Id", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(GameCreateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            await _gameService.AddGameAsync(model);
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _gameService.DeleteGameAsync(id);
            return RedirectToAction("Index");
        }
    }
}
