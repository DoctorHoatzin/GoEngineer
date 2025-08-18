using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Database;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using GalaxyFarFarAway.ViewModels;

namespace GalaxyFarFarAway.Services
{
    public class StarWarsDatabaseSeeder : IHostedService
    {
        public StarWarsDatabaseSeeder(IServiceProvider serviceProvider, ILogger<StarWarsDatabaseSeeder> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var apiService = scope.ServiceProvider.GetRequiredService<StarWarsAPIService>();

            if (!db.Starships.Any())
            {
                Console.WriteLine("List of Starships is Empty");
                var starships = await apiService.GetStarshipsFromApiAsync<List<StarshipViewModel>>("/starships");
                foreach (var ship in starships)
                {
                    if (!string.IsNullOrEmpty(ship.Crew))
                    {
                        if (ship.Crew.Contains('-'))
                        {
                            var hyphen = ship.Crew.IndexOf('-');
                            ship.MinimumCrew = ship.Crew.Substring(0, hyphen);
                            ship.MaximumCrew = ship.Crew.Substring(hyphen + 1);
                        }
                        else
                        {
                            ship.MinimumCrew = ship.Crew;
                            ship.MaximumCrew = ship.Crew;
                        }
                    }
                    ship.PublicId = Guid.NewGuid();
                    db.Starships.Add(ship);
                }
                await db.SaveChangesAsync();
            }
            Console.WriteLine("Starships already exist in the database.");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<StarWarsDatabaseSeeder> _logger;
    }
}
