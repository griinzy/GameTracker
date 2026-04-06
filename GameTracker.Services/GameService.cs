using GameTracker.Data;
using GameTracker.Data.Models;
using GameTracker.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GameTracker.Services
{
    public class GameService
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

        public async Task<PaginatedGamesViewModel> GetAllGamesPaginatedAsync(int page = 1, int pageSize = 10, string? sortBy = null, string? searchTitle = null, int? genreId = null, int? developerId = null)
        {
            var query = _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Developer)
                .AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchTitle))
            {
                query = query.Where(g => g.Title.Contains(searchTitle));
            }

            if(genreId != null)
            {
                query = query.Where(g => g.GenreId == genreId.Value);
            }

            if(developerId != null)
            {
                query = query.Where(g => g.DeveloperId == developerId.Value);
            }

            switch(sortBy)
            {
                case "title":
                    query = query.OrderBy(g => g.Title);
                    break;
                case "genre":
                    query = query.OrderBy(g => g.Genre.Name);
                    break;
                case "developer":
                    query = query.OrderBy(g => g.Developer.Name);
                    break;
                default:
                    query = query.OrderBy(g => g.Title);
                    break;
            }

            var totalGames = await query.CountAsync();

            var games = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
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

            return new PaginatedGamesViewModel
            {
                Games = games,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalGames / (double)pageSize),
                SortBy = sortBy,
                SearchTitle = searchTitle,
                GenreId = genreId,
                DeveloperId = developerId,
                Genres = await GetGenresAsync(),
                Developers = await GetDevelopersAsync()
            };
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

        public async Task<GameDetailsViewModel> GetGameDetailsByIdAsync(int id)
        {
            var game = await _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Developer)
                .FirstOrDefaultAsync(g => g.Id == id);

            return new GameDetailsViewModel
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre.Name,
                Developer = game.Developer.Name
            };
                
        }

        public async Task<GameEditViewModel> GetGameForEditByIdAsync(int id)
        {
            var game = await _context.Games
               .Include(g => g.Genre)
               .Include(g => g.Developer)
               .FirstOrDefaultAsync(g => g.Id == id);

            return new GameEditViewModel
            {
                Id = game.Id,
                Title = game.Title,
                ImageUrl = game.ImageUrl,
                Description = game.Description,
                GenreId = game.Genre.Id,
                DeveloperId = game.Developer.Id
            };
        }

        public async Task<GameDeleteViewModel> GetGameForDeletionByIdAsync(int id)
        {
            var game = await _context.Games
              .Include(g => g.Genre)
              .Include(g => g.Developer)
              .FirstOrDefaultAsync(g => g.Id == id);

            return new GameDeleteViewModel
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre.Name,
                Developer = game.Developer.Name
            };
        }

        public async Task EditGameAsync(GameEditViewModel model)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == model.Id);
            
            game.Title = model.Title;
            game.ImageUrl = model.ImageUrl;
            game.Description = model.Description;
            game.GenreId = model.GenreId;
            game.DeveloperId = model.DeveloperId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = _context.Games.Find(id);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public async Task SaveGameAsync(int id, string userId)
        {
            var saveExists = await _context.UserGames
                .AnyAsync(g => g.GameId == id && g.User.Id == userId);

            if (!saveExists)
            {
                var userGame = new UserGame
                {
                    UserId = userId,
                    GameId = id,
                    Status = GameStatus.Playing,
                    Rating = 0
                };

                await _context.UserGames.AddAsync(userGame);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GameSaveViewModel>> GetSavedGamesAsync(string userId)
        {
            var games = await _context.UserGames
                .Where(g => g.UserId == userId)
                .Select(g => new GameSaveViewModel
                {
                    Id = g.Id,
                    Title = g.Game.Title,
                    Status = g.Status,
                    Rating = g.Rating,
                    AddedOn = g.AddedOn
                })
                .ToListAsync();

            return games;
        }

        public async Task<GameSaveViewModel> GetSavedGameByIdAsync(int id, string userId)
        {
            var savedGame = await _context.UserGames
                .Where(g => g.Id == id && g.UserId == userId)
                .Select(g => new GameSaveViewModel
                {
                    Id = g.Id,
                    Title = g.Game.Title,
                    Status = g.Status,
                    Rating = g.Rating,
                    AddedOn = g.AddedOn
                })
                .FirstOrDefaultAsync();
            return savedGame;
        }

        public async Task EditSavedGameAsync(GameSaveViewModel model)
        {
            var savedGame = await _context.UserGames
                .FirstOrDefaultAsync(g => g.Id == model.Id);

            savedGame.Status = model.Status;
            savedGame.Rating = model.Rating;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSavedGame(int id)
        {
            var savedGame = _context.UserGames.Find(id);
            _context.UserGames.Remove(savedGame);
            _context.SaveChanges();
        }
    }
}
