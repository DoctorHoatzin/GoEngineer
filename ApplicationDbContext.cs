using GalaxyFarFarAway.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<StarshipViewModel> Starships { get; set; }
    }
}
