using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Resident Evil 4");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DeveloperId", "GenreId", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 6, "When a young street hustler, a retired bank robber, and a terrifying psychopath find themselves entangled with some of the most frightening and deranged elements of the criminal underworld, the U.S. government, and the entertainment industry, they must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody — least of all each other.", 4, 4, "https://cdn.steamstatic.com/steamcommunity/public/images/apps/271590/06b52e09e284542dd99eea45f9f85f68440dbcaf.ico", "Grand Theft Auto V" },
                    { 7, "A deadly virus engulfs the residents of Raccoon City in September of 1998, plunging the city into chaos as flesh eating zombies roam the streets for survivors. An unparalleled adrenaline rush, gripping storyline, and unimaginable horrors await you. ", 2, 2, "https://cdn.steamstatic.com/steamcommunity/public/images/apps/883710/944337601cbaf7e04fb397170ec25124f5b34822.ico", "Resident Evil 2" },
                    { 8, "Jill Valentine is one of the last remaining people in Raccoon City to witness the atrocities Umbrella performed. To stop her, Umbrella unleashes their ultimate secret weapon: Nemesis!", 2, 2, "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/952060/916c824e7c5becfb7d5e411ce751146cef78b3b4.ico", "Resident Evil 3" },
                    { 9, "Reawakened from stasis in the occupied metropolis of City 17, Gordon Freeman is joined by Alyx Vance as he leads a desperate human resistance. Experience the landmark first-person shooter packed with immersive world-building, boundary-pushing physics, and exhilarating combat.", 5, 5, "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/220/85c721efacb1b0903fa11e993291c33da8f643d1.ico", "Half-Life 2" },
                    { 10, "Then, there was fire. Re-experience the critically acclaimed, genre-defining game that started it all.", 1, 1, "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/570940/b3c6922185ecc5b42e188e0c5cdcdea11d419539.ico", "Dark Souls 1" },
                    { 11, "Dark Souls continues to push the boundaries with the latest, ambitious chapter in the critically-acclaimed and genre-defining series. Prepare yourself and Embrace The Darkness! ", 1, 1, "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/374320/e9bb44e88f49a1491db1664ec765e90e7debc3ea.ico", "Dark Souls 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Resident Evil 4 Remake");
        }
    }
}
