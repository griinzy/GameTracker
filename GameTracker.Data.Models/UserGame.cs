using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Data.Models
{
    public class UserGame
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; } = null!;
        public int GameId { get; set; }
        public virtual Game Game { get; set; } = null!;
        public GameStatus Status { get; set; }
        public int Rating { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}
