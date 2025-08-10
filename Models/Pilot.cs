using System.ComponentModel.DataAnnotations;

namespace GalaxyFarFarAway
{
    public class Pilot
    {
        [Key]
        private int Id { get; set; }
        private string Name { get; set; }
        private int StarShipId { get; set; }
        private Starship Starship { get; set; }
    }
}
