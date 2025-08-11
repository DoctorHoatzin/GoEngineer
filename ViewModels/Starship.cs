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
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        [JsonPropertyName("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }
        [JsonPropertyName("crew")]
        [NotMapped]
        public string Crew { get; set; }
        public string MinimumCrew { get; set; }
        public string MaximumCrew { get; set; }
        [JsonPropertyName("passengers")]
        public string PassengerCapacity { get; set; }
        [JsonPropertyName("cargo_capacity")]
        public string CargoCapacity { get; set; }
        [JsonPropertyName("consumables")]
        public string ConsumablesInYears { get; set; }
        [JsonPropertyName("hyperdrive_rating")]
        public string HyperdriveRating { get; set; }
        [JsonPropertyName("MGLT")]
        public string MegaLightPerHour { get; set; }
        [JsonPropertyName("starship_class")]
        public string StarshipClass { get; set; }
        public IEnumerable<string> Pilots { get; set; }
        public IEnumerable<string> Films { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        [JsonPropertyName("url")]
        public string APIUrl { get; set; }
    }

    public class StarshipResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("next")]
        public string Next { get; set; }
        [JsonPropertyName("previous")]
        public string Previous { get; set; }
        [JsonPropertyName("results")]
        public List<Starship> Results { get; set; }
    }
}
