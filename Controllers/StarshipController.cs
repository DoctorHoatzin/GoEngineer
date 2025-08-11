using Microsoft.AspNetCore.Mvc;
using Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GalaxyFarFarAway.ViewModels;

namespace GalaxyFarFarAway.Controllers
{
    public class StarshipController : Controller
    {
        public StarshipController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var starships = new StarshipViewModel();
            return View();
        }

        private readonly ApplicationDbContext _db;
    }
}
