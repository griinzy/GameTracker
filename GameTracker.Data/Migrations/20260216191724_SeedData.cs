using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "FromSoftware" },
                    { 2, "Capcom" },
                    { 3, "Team Cherry" },
                    { 4, "Rockstar Games" },
                    { 5, "Valve" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action RPG" },
                    { 2, "Survival Horror" },
                    { 3, "Metroidvania" },
                    { 4, "Action-Adventure" },
                    { 5, "First-Person Shooter" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DeveloperId", "GenreId", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Set in the haunting Gothic city of Yharnam, players battle terrifying beasts and unravel eldritch mysteries in fast‑paced, high‑risk combat.", 1, 1, "https://cdn2.steamgriddb.com/icon/22c5a901070d1c2ad33e821d071ae97e/32/256x256.png", "Bloodborne" },
                    { 2, "Leon Kennedy returns in this modernized remake, fighting through a rural European village overrun by a mysterious cult, combining intense combat with horror and puzzle-solving.", 2, 2, "https://cdn2.steamgriddb.com/icon/288277613d0286fded7bc1d0bcfaa2dc/32/256x256.png", "Resident Evil 4 Remake" },
                    { 3, "A beautifully atmospheric 2D action‑adventure set in the sprawling underground world of Hallownest, full of secrets, challenging foes, and exploration.", 3, 3, "https://cdn2.steamgriddb.com/icon/4158f6d19559955bae372bb00f6204e4/32/256x256.png", "Hollow Knight" },
                    { 4, "A rich, narrative‑driven experience in the American frontier, blending story, exploration, and dynamic open‑world gameplay.", 4, 4, "https://cdn2.steamgriddb.com/icon/1ce4fe042832e6bd7d06697a43055373/32/256x256.png", "Red Dead Redemption 2" },
                    { 5, "The successor to Counter‑Strike: Global Offensive, CS2 offers refined tactical gameplay, upgraded visuals, and competitive team‑based shooting focused on precision and strategy.", 5, 5, "https://cdn2.steamgriddb.com/icon/e1bd06c3f8089e7552aa0552cb387c92/32/256x256.png", "Counter‑Strike 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "UserGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
