using FormulaApp.API.Configuration;
using FormulaApp.API.Models;
using FormulaApp.API.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace FormulaApp.API.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiServiceConfig _apiConfig;
        public FanService(HttpClient httpClient, IOptions<ApiServiceConfig> config) {
            _httpClient = httpClient;
            _apiConfig = config.Value;
        }

        public async Task<List<Fan>?> GetAllFans()
        {
            /*var fans = new List<Fan>
                {
                    new Fan()
                    {
                        Id = 1,
                        Name = "Test",
                        Email = "test@email.com"
                    },
                    new Fan()
                    {
                        Id = 2,
                        Name = "don",
                        Email = "don.donne@email.com"
                    },
                };*/

            var response = await _httpClient.GetAsync(_apiConfig.Url);

            if(response.StatusCode == HttpStatusCode.NotFound)
                return new List<Fan>();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;


            var fans = await response.Content.ReadFromJsonAsync<List<Fan>>();

            return fans;
            
        }

        

    }
}

