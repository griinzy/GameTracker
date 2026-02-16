# GameTracker

## About
GameTracker is a web application that allows users to browser video games, save their favorites, rate them and track their progress. 

## Main Features
- Browse a list of games with images, descriptions, genres and developers.
- Add, edit or remove games from the public list of games.
- Save games to your personal collection.
- Edit or delete saved games from your collection.
- Rate your saved games.
- Track the status of your games (Playing, Completed, Backlogged).
- Authentication - only logged in users can save, edit, delete games or save games to their collection.

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core with SQL Server
- Razor Pages
- Bootstrap 5

## Setup Instructions
1. Open the solution with Visual Studio.

2. Configure the connection string in `appsettings.json` if needed.

3. Apply migrations and seed data if needed.
    - Open Tools -> NuGet Package Manager -> Package Manager Console.
    - Run the command `Update-Database`.

4. Run the project.

5. Register a user.
    - You need to register an account so add, edit or remove games.

### Notes
- Seeded data includes 5 games, 5 genres and 5 developers.
