using GameTracker.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.ViewModels
{
    public class GameCreateViewModel
    {
        [Required]
        [MaxLength(ValidationConstraints.GameTitleMaxLength)]
        [MinLength(ValidationConstraints.GameTitleMinLength)]
        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [MinLength(ValidationConstraints.GameDescriptionMinLength)]
        [MaxLength(ValidationConstraints.GameDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int DeveloperId { get; set; }
    }
}
