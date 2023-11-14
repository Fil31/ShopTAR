using Newtonsoft.Json;
using Shop.Core.Dto.NorrisDtos;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class ChuckNorrisService : IChuckNorrisService
    {
        private readonly HttpClient _httpClient;

        public ChuckNorrisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NorrisResponseRootDto> GetRandomJokeAsync()
        {
            var response = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NorrisResponseRootDto>(content);
        }
    }
}
