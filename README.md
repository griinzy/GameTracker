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
- ASP.NET Identity
- Entity Framework Core with SQL Server
- Razor Pages
- Bootstrap 5

## Architecture
The project is split into multiple projects.

## Layers
### GameTracker.Web
The main ASP.NET Core Application.

### GameTracker.Services
The business logic of the application.

### GameTracker.Data
Responsible for database access.

### GameTracker.ViewModels
Used for data transfer between the UI and backend.

### GameTracker.Common
Contains the constraints of the models.

### GameTracker.UnitTests
Contains Unit tests.

## Seeding
The database is seeded in `ApplicationDbContext`.
Seeded data includes 11 games, 5 genres and 5 developers.

## Test Coverage
Tests include the Game and Admin controllers, as well as the fetching of games, game details, genres, developers, adding games, genres, developers, deleting games in GameService.

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
- An admin user is included with email `admin@mail.com` and password `admin123`.
