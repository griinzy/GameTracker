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
        Task<IEnumerable<GenreViewModel>> GetGenresAsync();
        Task<IEnumerable<DeveloperViewModel>> GetDevelopersAsync();
        Task AddGameAsync(GameCreateViewModel model);
        Task AddGenreAsync(CreateGenreViewModel model);
        Task AddDeveloperAsync(CreateDeveloperViewModel model);


    }
}
