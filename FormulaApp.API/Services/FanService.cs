using FormulaApp.API.Models;
using FormulaApp.API.Services.Interfaces;

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
            throw new NotImplementedException();
        }
    }
}
