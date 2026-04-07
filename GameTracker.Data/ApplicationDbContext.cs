using GameTracker.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace GameTracker.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; } = null!;
    public virtual DbSet<Genre> Genres { get; set; } = null!;
    public virtual DbSet<Developer> Developers { get; set; } = null!;
    public virtual DbSet<UserGame> UserGames { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action RPG" },
            new Genre { Id = 2, Name = "Survival Horror" },
            new Genre { Id = 3, Name = "Metroidvania" },
            new Genre { Id = 4, Name = "Action-Adventure" },
            new Genre { Id = 5, Name = "First-Person Shooter" }
        );

        builder.Entity<Developer>().HasData(
            new Developer { Id = 1, Name = "FromSoftware" },
            new Developer { Id = 2, Name = "Capcom" },
            new Developer { Id = 3, Name = "Team Cherry" },
            new Developer { Id = 4, Name = "Rockstar Games" },
            new Developer { Id = 5, Name = "Valve" }
        );

        builder.Entity<Game>().HasData(
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
                Title = "Resident Evil 4",
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
            },
            new Game
            {
                Id = 6,
                Title = "Grand Theft Auto V",
                ImageUrl = "https://cdn.steamstatic.com/steamcommunity/public/images/apps/271590/06b52e09e284542dd99eea45f9f85f68440dbcaf.ico",
                Description = "When a young street hustler, a retired bank robber, and a terrifying psychopath find themselves entangled with some of the most frightening and deranged elements of the criminal underworld, the U.S. government, and the entertainment industry, they must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody — least of all each other.",
                GenreId = 4,
                DeveloperId = 4
            },
            new Game
            {
                Id = 7,
                Title = "Resident Evil 2",
                ImageUrl = "https://cdn.steamstatic.com/steamcommunity/public/images/apps/883710/944337601cbaf7e04fb397170ec25124f5b34822.ico",
                Description = "A deadly virus engulfs the residents of Raccoon City in September of 1998, plunging the city into chaos as flesh eating zombies roam the streets for survivors. An unparalleled adrenaline rush, gripping storyline, and unimaginable horrors await you. ",
                GenreId = 2,
                DeveloperId = 2
            },
            new Game
            {
                Id = 8,
                Title = "Resident Evil 3",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/952060/916c824e7c5becfb7d5e411ce751146cef78b3b4.ico",
                Description = "Jill Valentine is one of the last remaining people in Raccoon City to witness the atrocities Umbrella performed. To stop her, Umbrella unleashes their ultimate secret weapon: Nemesis!",
                GenreId = 2,
                DeveloperId = 2
            },
            new Game
            {
                Id = 9,
                Title = "Half-Life 2",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/220/85c721efacb1b0903fa11e993291c33da8f643d1.ico",
                Description = "Reawakened from stasis in the occupied metropolis of City 17, Gordon Freeman is joined by Alyx Vance as he leads a desperate human resistance. Experience the landmark first-person shooter packed with immersive world-building, boundary-pushing physics, and exhilarating combat.",
                GenreId = 5,
                DeveloperId = 5
            },
            new Game
            {
                Id = 10,
                Title = "Dark Souls 1",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/570940/b3c6922185ecc5b42e188e0c5cdcdea11d419539.ico",
                Description = "Then, there was fire. Re-experience the critically acclaimed, genre-defining game that started it all.",
                GenreId = 1,
                DeveloperId = 1
            },
            new Game
            {
                Id = 11,
                Title = "Dark Souls 3",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/374320/e9bb44e88f49a1491db1664ec765e90e7debc3ea.ico",
                Description = "Dark Souls continues to push the boundaries with the latest, ambitious chapter in the critically-acclaimed and genre-defining series. Prepare yourself and Embrace The Darkness! ",
                GenreId = 1,
                DeveloperId = 1
            }
        );
    }
}
