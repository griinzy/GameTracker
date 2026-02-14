using GameTracker.Common;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Data.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstraints.GameTitleMinLength)]
        [MaxLength(ValidationConstraints.GameTitleMaxLength)]
        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [MinLength(ValidationConstraints.GameDescriptionMinLength)]
        [MaxLength(ValidationConstraints.GameDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;

        [Required]
        public int DeveloperId { get; set; }
        public virtual Developer Developer { get; set; } = null!;

        public virtual ICollection<UserGame> UserGames { get; set; } = new HashSet<UserGame>();
    }
}
