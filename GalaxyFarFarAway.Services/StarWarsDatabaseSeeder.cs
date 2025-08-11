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
                var starships = await apiService.GetStarshipsFromApiAsync<StarshipResponse>("/starships");
                var starshipData = starships.Results;
                foreach (var ship in starshipData)
                {
                    db.Starships.Add(ship);
                }
                await db.SaveChangesAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<StarWarsDatabaseSeeder> _logger;
    }
}
