using System.ComponentModel.DataAnnotations;

namespace GalaxyFarFarAway.ViewModels
{
    public class FilmViewModel
    {
        [Key]
        private int Id { get; set; }
        private string Title { get; set; }
        private int StarShipId { get; set; }
        private StarshipViewModel Starship { get; set; }
    }
}
