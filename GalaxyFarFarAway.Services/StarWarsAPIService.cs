using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GalaxyFarFarAway.Services
{
    public class StarWarsAPIService
    {
        public StarWarsAPIService(HttpClient httpClient, IOptions<StarWarsApiSettings> options)
        {
            _httpClient = httpClient;
            _baseUrl = options.Value.BaseUrl;
        }
        public async Task<T?> GetStarshipsFromApiAsync<T>(string endpoint)
        {
            var json = await _httpClient.GetStringAsync($"{_baseUrl}/{endpoint}");
            return JsonSerializer.Deserialize<T>(json);
        }

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
    }
}
