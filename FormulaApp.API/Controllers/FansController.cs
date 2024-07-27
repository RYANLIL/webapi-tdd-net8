using FormulaApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FansController : ControllerBase
    {
        private readonly IFanService _fastaService;

        public FansController(IFanService fanService)
        {
            _fastaService = fanService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetFans()
        {
            var fans = await _fastaService.GetAllFans();

            if(fans.Any())
            {
                return Ok(fans); //returns HttpStatusCode 200
            }

            return NotFound();

        }
    }


}
