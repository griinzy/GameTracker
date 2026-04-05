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
        public async Task<IActionResult> Index(int page = 1, string? sortBy = null, string? searchTitle = null)
        {
            var model = await _gameService.GetAllGamesPaginatedAsync(page, 10, sortBy, searchTitle);
            return View(model);
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
    }
}
