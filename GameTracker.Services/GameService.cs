using GameTracker.Data;
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
    }
}
