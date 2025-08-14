using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace GalaxyFarFarAway.Services
{
    public class UserIdentityRoleSeeder : IHostedService
    {
        public UserIdentityRoleSeeder(IServiceProvider serviceProvider, ILogger<UserIdentityRoleSeeder> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken token)
        {
            using var scope = _serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var identityRole = new IdentityRole(role);
                    var result = await roleManager.CreateAsync(identityRole);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation($"Role '{role}' created successfully.");
                    }
                    else
                    {
                        _logger.LogError($"Failed to create role '{role}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
            }

            var adminEmail = "galaxy@farfaraway.force";
            var adminPassword = "Alta1N@";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var createAdmin = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdmin.Succeeded) 
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    _logger.LogInformation($"Admin user '{adminEmail}' created and added to 'Admin' role.");
                }
                else
                {
                    _logger.LogError($"Failed to create admin user '{adminEmail}': {string.Join(", ", createAdmin.Errors.Select(e => e.Description))}");
                }
            }

            var userEmail = "pilot@farfaraway.force";
            var userPassword = "@Nt1ll3s";
            var baseUser = await userManager.FindByEmailAsync(userEmail);
            if (baseUser == null)
            {
                baseUser = new IdentityUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true
                };
                var createUser = await userManager.CreateAsync(baseUser, userPassword);
                if (createUser.Succeeded) 
                {
                    await userManager.AddToRoleAsync(baseUser, "User");
                    _logger.LogInformation($"Base user '{userEmail}' created and added to 'User' role.");
                }
                else
                {
                    _logger.LogError($"Failed to create base user '{userEmail}': {string.Join(", ", createUser.Errors.Select(e => e.Description))}");
                }
            }
        }

        public Task StopAsync(CancellationToken token)
        {
            return Task.CompletedTask;
        }

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<UserIdentityRoleSeeder> _logger;
    }
}
