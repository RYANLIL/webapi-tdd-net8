using FormulaApp.API.Models;
using FormulaApp.API.Services.Interfaces;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace FormulaApp.API.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;
        public FanService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<List<Fan>> GetAllFans()
        {
            var fans = new List<Fan>
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
                };

            return fans;
        }

        

    }
}

