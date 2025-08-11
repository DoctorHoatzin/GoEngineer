using System.ComponentModel.DataAnnotations;

namespace GalaxyFarFarAway.ViewModels
{
    public class PilotViewModel
    {
        [Key]
        private int Id { get; set; }
        private string Name { get; set; }
        private int StarShipId { get; set; }
        private StarshipViewModel Starship { get; set; }
    }
}
