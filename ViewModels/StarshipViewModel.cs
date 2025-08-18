using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GalaxyFarFarAway.ViewModels
{
    public class StarshipViewModel
    {
        [Key]
        public int Id { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid();
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("model")]
        public string? Model { get; set; }
        [JsonPropertyName("manufacturer")]
        public string? Manufacturer { get; set; }
        [JsonPropertyName("cost_in_credits")]
        public string? CostInCredits { get; set; }
        [JsonPropertyName("length")]
        public string? Length { get; set; }
        [JsonPropertyName("max_atmosphering_speed")]
        public string? MaxAtmospheringSpeed { get; set; }
        [JsonPropertyName("crew")]
        [NotMapped]
        public string? Crew { get; set; }
        public string? MinimumCrew { get; set; }
        public string? MaximumCrew { get; set; }
        [JsonPropertyName("passengers")]
        public string? PassengerCapacity { get; set; }
        [JsonPropertyName("cargo_capacity")]
        public string? CargoCapacity { get; set; }
        [JsonPropertyName("consumables")]
        public string? ConsumablesInYears { get; set; }
        [JsonPropertyName("hyperdrive_rating")]
        public string? HyperdriveRating { get; set; }
        [JsonPropertyName("MGLT")]
        public string? MegaLightPerHour { get; set; }
        [JsonPropertyName("starship_class")]
        public string? StarshipClass { get; set; }
        [JsonPropertyName("pilots")]
        public IEnumerable<string>? Pilots { get; set; }
        [JsonPropertyName("films")]
        public IEnumerable<string>? Films { get; set; }
        [JsonPropertyName("created")]
        public DateTime DateCreated { get; set; }
        [JsonPropertyName("edited")]
        public DateTime DateLastUpdated { get; set; }
        [JsonPropertyName("url")]
        public string? APIUrl { get; set; }
    }
}
