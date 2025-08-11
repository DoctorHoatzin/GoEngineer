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
            var starships = new List<StarshipViewModel>();
            starships = _db.Starships.ToList();
            var vmList = starships.Select(s => new StarshipViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Model = s.Model,
                Manufacturer = s.Manufacturer,
                CostInCredits = s.CostInCredits,
                Length = s.Length,
                MaxAtmospheringSpeed = s.MaxAtmospheringSpeed,
                MinimumCrew = s.MinimumCrew,
                MaximumCrew = s.MaximumCrew,
                PassengerCapacity = s.PassengerCapacity,
                CargoCapacity = s.CargoCapacity,
                ConsumablesInYears = s.ConsumablesInYears,
                HyperdriveRating = s.HyperdriveRating,
                MegaLightPerHour = s.MegaLightPerHour,
                StarshipClass = s.StarshipClass,
                Pilots = s.Pilots,
                Films = s.Films,
                DateCreated = s.DateCreated,
                DateLastUpdated = s.DateLastUpdated,
                APIUrl = s.APIUrl
            }).ToList();
            return View("~/Views/Starship/Index.cshtml", vmList);
        }

        private readonly ApplicationDbContext _db;
    }
}
