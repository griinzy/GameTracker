using GameTracker.Data;
using GameTracker.Data.Models;
using GameTracker.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;

        public GameService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameIndexViewModel>> GetAllGamesAsync()
        {
            return await _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Developer)
                .Include(g => g.UserGames)
                .Select(g => new GameIndexViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    Genre = g.Genre.Name,
                    Developer = g.Developer.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GenreViewModel>> GetGenresAsync()
        {
            return await _context.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DeveloperViewModel>> GetDevelopersAsync()
        {
            return await _context.Developers
                .Select(g => new DeveloperViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }

        public async Task AddGameAsync(GameCreateViewModel model)
        {
            var game = new Game
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                GenreId = model.GenreId,
                DeveloperId = model.DeveloperId
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task AddGenreAsync(CreateGenreViewModel model)
        {
            var genre = new Genre
            {
                Name = model.Name
            };

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task AddDeveloperAsync(CreateDeveloperViewModel model)
        {
            var developer = new Developer
            {
                Name = model.Name
            };

            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
        }
    }
}
