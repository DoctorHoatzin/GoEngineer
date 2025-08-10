using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GalaxyFarFarAway;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GalaxyFarFarAway.Services
{
    public class StarWarsDatabaseSeeder : IHostedService
    {
        public StarWarsDatabaseSeeder(IServiceProvider serviceProvider, ILogger<StarWarsDatabaseSeeder> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken token)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (await dbContext.Database.EnsureCreatedAsync(token))
                {
                    _logger.LogInformation("Database created successfully.");
                }
                else
                {
                    _logger.LogInformation("Database already exists.");
                }
            }
        }

        public async Task StopAsync(CancellationToken token)
        {

        }

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<StarWarsDatabaseSeeder> _logger;
    }
}
