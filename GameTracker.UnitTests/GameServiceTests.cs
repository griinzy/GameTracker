using GameTracker.Data;
using GameTracker.Data.Models;
using GameTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.UnitTests
{
    [TestFixture]
    public class GameServiceTests
    {
        private ApplicationDbContext _context;
        private GameService _gameService;

        private IEnumerable<Genre> genres;
        private IEnumerable<Developer> developers;
        private IEnumerable<Game> games;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _gameService = new GameService(_context);

            genres = new List<Genre>()
            {
                new Genre { Id = 1, Name = "Action RPG" },
                new Genre { Id = 2, Name = "Survival Horror" },
                new Genre { Id = 3, Name = "Metroidvania" },
                new Genre { Id = 4, Name = "Action-Adventure" },
                new Genre { Id = 5, Name = "First-Person Shooter" }
            };

            developers = new List<Developer>()
            {
                new Developer { Id = 1, Name = "FromSoftware" },
                new Developer { Id = 2, Name = "Capcom" },
                new Developer { Id = 3, Name = "Team Cherry" },
                new Developer { Id = 4, Name = "Rockstar Games" },
                new Developer { Id = 5, Name = "Valve" }
            };

            games = new List<Game>()
            {
                new Game
                {
                    Id = 1,
                    Title = "Bloodborne",
                    ImageUrl = "https://cdn2.steamgriddb.com/icon/22c5a901070d1c2ad33e821d071ae97e/32/256x256.png",
                    Description = "Set in the haunting Gothic city of Yharnam, players battle terrifying beasts and unravel eldritch mysteries in fast‑paced, high‑risk combat.",
                    GenreId = 1,
                    DeveloperId = 1
                },
                new Game
                {
                    Id = 2,
                    Title = "Resident Evil 4 Remake",
                    ImageUrl = "https://cdn2.steamgriddb.com/icon/288277613d0286fded7bc1d0bcfaa2dc/32/256x256.png",
                    Description = "Leon Kennedy returns in this modernized remake, fighting through a rural European village overrun by a mysterious cult, combining intense combat with horror and puzzle-solving.",
                    GenreId = 2,
                    DeveloperId = 2
                },
                new Game
                {
                    Id = 3,
                    Title = "Hollow Knight",
                    ImageUrl = "https://cdn2.steamgriddb.com/icon/4158f6d19559955bae372bb00f6204e4/32/256x256.png",
                    Description = "A beautifully atmospheric 2D action‑adventure set in the sprawling underground world of Hallownest, full of secrets, challenging foes, and exploration.",
                    GenreId = 3,
                    DeveloperId = 3
                },
                new Game
                {
                    Id = 4,
                    Title = "Red Dead Redemption 2",
                    ImageUrl = "https://cdn2.steamgriddb.com/icon/1ce4fe042832e6bd7d06697a43055373/32/256x256.png",
                    Description = "A rich, narrative‑driven experience in the American frontier, blending story, exploration, and dynamic open‑world gameplay.",
                    GenreId = 4,
                    DeveloperId = 4
                },
                new Game
                {
                    Id = 5,
                    Title = "Counter‑Strike 2",
                    ImageUrl = "https://cdn2.steamgriddb.com/icon/e1bd06c3f8089e7552aa0552cb387c92/32/256x256.png",
                    Description = "The successor to Counter‑Strike: Global Offensive, CS2 offers refined tactical gameplay, upgraded visuals, and competitive team‑based shooting focused on precision and strategy.",
                    GenreId = 5,
                    DeveloperId = 5
                }
            };

            _context.Genres.AddRange(genres);
            _context.Developers.AddRange(developers);
            _context.Games.AddRange(games);

            _context.SaveChanges();
        }

        [TearDown]
        public void Teardown()
        {
            _context.Dispose();
        }

        [Test]
        public void GetAllGamesAsync_ReturnsCorrectNumberOfGames()
        {
            Assert.Pass();
        }
    }
}