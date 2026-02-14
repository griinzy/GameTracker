using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameTracker.Common;

namespace GameTracker.Data.Models
{
    public class Developer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstraints.DeveloperNameMinLength)]
        [MaxLength(ValidationConstraints.DeveloperNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
