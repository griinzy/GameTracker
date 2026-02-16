using GameTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.ViewModels
{
    public class GameSaveViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GameStatus Status { get; set; }
        public int Rating { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
