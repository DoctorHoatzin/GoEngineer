using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GalaxyFarFarAway.ViewModels
{
    public class Starship
    {
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }
        [JsonPropertyName("cost_in_credits")]
        public float? CostInCredits { get; set; }
        public float? Length { get; set; }
        [JsonPropertyName("max_atmosphering_speed")]
        public float? MaxAtmospheringSpeed { get; set; }
        [JsonPropertyName("crew")]
        [NotMapped]
        public string Crew { get; set; }
        public int? MinimumCrew { get; set; }
        public int? MaximumCrew { get; set; }
        [JsonPropertyName("passengers")]
        public int? PassengerCapacity { get; set; }
        [JsonPropertyName("cargo_capacity")]
        public int? CargoCapacity { get; set; }
        [JsonPropertyName("consumables")]
        public int? ConsumablesInYears { get; set; }
        [JsonPropertyName("hyperdrive_rating")]
        public float? HyperdriveRating { get; set; }
        [JsonPropertyName("MGLT")]
        public int? MegaLightPerHour { get; set; }
        [JsonPropertyName("starship_class")]
        public string StarshipClass { get; set; }
        public IEnumerable<string> Pilots { get; set; }
        public IEnumerable<string> Films { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string APIUrl { get; set; }
    }

    public class StarshipResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Starship> Results { get; set; }
    }
}
