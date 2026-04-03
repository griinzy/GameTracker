using GameTracker.Services;
using GameTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Web.Controllers
{
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
        public async Task<IActionResult> CreateGenre()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _gameService.AddGenreAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateDeveloper()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDeveloper(CreateDeveloperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _gameService.AddDeveloperAsync(model);
            return RedirectToAction("Index");
        }

    }
}
