using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.ViewModels
{
    public class PaginatedGamesViewModel
    {
        public IEnumerable<GameIndexViewModel> Games { get; set; } = new List<GameIndexViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? SortBy { get; set; }
    }
}
