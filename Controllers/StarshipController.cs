using Microsoft.AspNetCore.Mvc;
using Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GalaxyFarFarAway.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace GalaxyFarFarAway.Controllers
{
    public class StarshipController : Controller
    {
        public StarshipController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public ActionResult Index()
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
            }).Where(static s => int.TryParse(s.MinimumCrew, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out int result) == true && result >= 200).ToList();
            return View("~/Views/Starship/Index.cshtml", vmList);
        }

        [HttpGet]
        public ActionResult Upsert(int id)
        {
            if (id == 0)
            {
                return PartialView("~/Views/Starship/StarshipForm.cshtml", new StarshipViewModel());
            }
            var ship = _db.Starships.FirstOrDefault(s => s.Id == id);
            if (ship != null)
            {
                var vm = new StarshipViewModel()
                {
                    Id = ship.Id,
                    Name = ship.Name,
                    Model = ship.Model,
                    Manufacturer = ship.Manufacturer,
                    CostInCredits = ship.CostInCredits,
                    Length = ship.Length,
                    MaxAtmospheringSpeed = ship.MaxAtmospheringSpeed,
                    MinimumCrew = ship.MinimumCrew,
                    MaximumCrew = ship.MaximumCrew,
                    PassengerCapacity = ship.PassengerCapacity,
                    CargoCapacity = ship.CargoCapacity,
                    ConsumablesInYears = ship.ConsumablesInYears,
                    HyperdriveRating = ship.HyperdriveRating,
                    MegaLightPerHour = ship.MegaLightPerHour,
                    StarshipClass = ship.StarshipClass,
                    Pilots = ship.Pilots,
                    Films = ship.Films,
                    DateCreated = ship.DateCreated,
                    DateLastUpdated = ship.DateLastUpdated,
                    APIUrl = ship.APIUrl
                };

                return PartialView("~/Views/Starship/StarshipForm.cshtml", vm);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Upsert(StarshipViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (vm.Id == 0)
            {
                var newShip = new StarshipViewModel()
                {
                    Name = vm.Name,
                    Model = vm.Model,
                    Manufacturer = vm.Manufacturer,
                    CostInCredits = vm.CostInCredits,
                    Length = vm.Length,
                    MaxAtmospheringSpeed = vm.MaxAtmospheringSpeed,
                    MinimumCrew = vm.MinimumCrew,
                    MaximumCrew = vm.MaximumCrew,
                    PassengerCapacity = vm.PassengerCapacity,
                    CargoCapacity = vm.CargoCapacity,
                    ConsumablesInYears = vm.ConsumablesInYears,
                    HyperdriveRating = vm.HyperdriveRating,
                    MegaLightPerHour = vm.MegaLightPerHour,
                    StarshipClass = vm.StarshipClass,
                    Pilots = vm.Pilots,
                    Films = vm.Films,
                    DateCreated = DateTime.Now,
                    DateLastUpdated = DateTime.Now,
                };
                _db.Starships.Add(newShip);
            }
            else
            {
                var ship = _db.Starships.FirstOrDefault(s => s.Id == vm.Id);
                if (ship != null)
                {
                    ship.Name = vm.Name;
                    ship.Model = vm.Model;
                    ship.Manufacturer = vm.Manufacturer;
                    ship.CostInCredits = vm.CostInCredits;
                    ship.Length = vm.Length;
                    ship.MaxAtmospheringSpeed = vm.MaxAtmospheringSpeed;
                    ship.MinimumCrew = vm.MinimumCrew;
                    ship.MaximumCrew = vm.MaximumCrew;
                    ship.PassengerCapacity = vm.PassengerCapacity;
                    ship.CargoCapacity = vm.CargoCapacity;
                    ship.ConsumablesInYears = vm.ConsumablesInYears;
                    ship.HyperdriveRating = vm.HyperdriveRating;
                    ship.MegaLightPerHour = vm.MegaLightPerHour;
                    ship.StarshipClass = vm.StarshipClass;
                    ship.Pilots = vm.Pilots;
                    ship.Films = vm.Films;
                    ship.DateCreated = vm.DateCreated;
                    ship.DateLastUpdated = DateTime.Now;
                    ship.APIUrl = null;
                    _db.Starships.Update(ship);
                }

            }
            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var ship = _db.Starships.FirstOrDefault(s => s.Id == id);
            if (ship != null)
            {
                _db.Starships.Remove(ship);
                _db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        private readonly ApplicationDbContext _db;
    }
}
