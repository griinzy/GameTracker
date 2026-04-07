using GameTracker.Services;
using GameTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameTracker.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly GameService _gameService;

        public AdminController(GameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateGenre()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _gameService.AddGenreAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateDeveloper()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDeveloper(CreateDeveloperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _gameService.AddDeveloperAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetGameForEditByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewBag.Genres = new SelectList(await _gameService.GetGenresAsync(), "Id", "Name");
            ViewBag.Developers = new SelectList(await _gameService.GetDevelopersAsync(), "Id", "Name");
            return View(game);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(GameEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _gameService.EditGameAsync(model);
            return RedirectToAction("Details", "Game", new { id = model.Id });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetGameForDeletionByIdAsync(id);
            if (game == null)
            {
                return NotFound();
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
