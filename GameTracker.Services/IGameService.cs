using GameTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameIndexViewModel>> GetAllGamesAsync();
        Task<PaginatedGamesViewModel> GetAllGamesPaginatedAsync(int page = 1, int pageSize = 10, string? sortBy = null, string? searchTitle = null, int? genreId = null, int? developerId = null);
        Task<IEnumerable<GenreViewModel>> GetGenresAsync();
        Task<IEnumerable<DeveloperViewModel>> GetDevelopersAsync();
        Task AddGameAsync(GameCreateViewModel model);
        Task AddGenreAsync(CreateGenreViewModel model);
        Task AddDeveloperAsync(CreateDeveloperViewModel model);
        Task<GameDetailsViewModel> GetGameDetailsByIdAsync(int id);
        Task<GameEditViewModel> GetGameForEditByIdAsync(int id);
        Task<GameDeleteViewModel> GetGameForDeletionByIdAsync(int id);
        Task EditGameAsync(GameEditViewModel model);
        Task DeleteGameAsync(int id);
        Task SaveGameAsync(int id, string userId);
        Task<IEnumerable<GameSaveViewModel>> GetSavedGamesAsync(string userId);
        Task<GameSaveViewModel> GetSavedGameByIdAsync(int id, string userId);
        Task EditSavedGameAsync(GameSaveViewModel model);
        Task DeleteSavedGame(int id);
    }
}
