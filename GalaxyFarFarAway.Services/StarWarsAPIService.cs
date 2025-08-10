using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

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
            return await _httpClient.GetFromJsonAsync<T>($"{_baseUrl}/{endpoint}");
        }

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
    }
}
