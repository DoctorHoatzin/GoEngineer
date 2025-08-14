Galaxy Far Far Away Project

This project is an ASP.NET Core MVC application that integrates with a Star Wars API and includes Identity for user authentication.

------------------------------------------------------------

Running the Project Locally

Prerequisites:
- SQL Server installed on your machine (LocalDB works fine)
- Visual Studio or another .NET development environment
- Ensure all required NuGet packages are installed

Steps:
1. Restore NuGet packages
   Packages used in individual projects are automatically restored when the solution is built. If needed, run:
   dotnet restore

2. Check the connection string
   The project uses a LocalDB connection string located in appsettings.json under DefaultConnection.
   Ensure it matches your local SQL Server setup.

3. Apply migrations
   The project contains pre-existing migrations. To create or update the database, run:
   Update-Database
   If needed, you can add a new migration with:
   Add-Migration <MigrationName>
   Update-Database
   Note: You may try running Update-Database first since migrations are already included in the project.

4. Run the project
   Launch the project through Visual Studio (or dotnet run). The database will be seeded automatically via the StarWarsDatabaseSeeder hosted service.
   You can see how the database is populated by the API and rendered on the page.

------------------------------------------------------------

Running the Project on Azure

- To run the project on Azure, publish only the main project, not the Services project.
- You will not have direct access to the Azure database, but any changes made through the site (add/edit/delete) are reflected in real time.

------------------------------------------------------------

Identity Login

- The application uses ASP.NET Core Identity for user authentication.
- Default user names and passwords for testing can be found in the UserIdentityRoleSeeder.cs file located in the GalaxyFarFarAway.Services project.
- The Admin credentials are the only ones that can add or delete entries from the table. The base user does not have those permissions.

------------------------------------------------------------

NuGet Packages

- NuGet packages installed in one project do not automatically carry over to other projects in the solution.
- Ensure each project has its required packages installed. Visual Studio typically restores them on build, but you can manually restore them with:
  dotnet restore

------------------------------------------------------------

Database Migration Notes

- The Starships table is created via migrations. If a table already exists or a migration fails, you may need to revert or drop the table.
- To revert a migration:
  Update-Database <PreviousMigrationName>
- If testing locally, you can drop the database manually and run:
  Update-Database
- Always verify that your connection string points to the correct database and that the environment (Development or Production) is correct to avoid affecting the wrong database.

------------------------------------------------------------

Manual API Seeder

- The StarWarsDatabaseSeeder service automatically populates the Starships table on first run.
- To manually seed or reseed data in your local database:
  1. Open a scope of your ApplicationDbContext in a console or temporary controller.
  2. Call the seeder directly:
     var seeder = new StarWarsDatabaseSeeder(serviceProvider, logger);
     await seeder.StartAsync(CancellationToken.None)
- This allows you to refresh the local database without rebuilding the project.

------------------------------------------------------------

Notes

- You can use your local database to test seeding, API population, and page rendering without affecting the Azure database.
- All migrations are included in the project, so running Update-Database should normally apply them correctly if your database is empty or matches the migration history.
- Ensure the correct environment is set (Development or Production) when applying migrations or running the application.
- On the off chance that there is an error declaring duplicate attributes in the services project, comment them out in ~~\GalaxyFarFarAway.Services\obj\Release\net8.0\GalaxyFarFarAway.Services.AssemblyInfo.cs