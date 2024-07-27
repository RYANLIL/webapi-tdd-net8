using FormulaApp.API.Models;

namespace FormulaApp.API.Services.Interfaces
{
    public interface IFanService
    {
        Task<List<Fan>> GetAllFans();
    }
}
