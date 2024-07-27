using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FansController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFans()
        {
            return Ok("Fans"); //returns HttpStatusCode 200
        }
    }
}
