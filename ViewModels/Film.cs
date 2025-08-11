using System.ComponentModel.DataAnnotations;

namespace GalaxyFarFarAway.ViewModels
{
    public class Film
    {
        [Key]
        private int Id { get; set; }
        private string Title { get; set; }
        private int StarShipId { get; set; }
        private Starship Starship { get; set; }
    }
}
