using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WineInventory.Controllers
{
    [Route("api/wine")]
    [ApiController]
    [Authorize]
    public class WineController : ControllerBase
    {
        public readonly IWineServices _wineServices;
        public WineController(IWineServices wineServices)
        {
            _wineServices = wineServices;
        }

        [HttpPost]
        public IActionResult AddWine([FromBody] WineDTO wineDTO)
        {
            if (wineDTO == null)
                return BadRequest("The body request is null");

            _wineServices.AddWine(wineDTO);
            return Created("Location", "Resource");
        }

        [HttpGet]
        public IActionResult GetAllWinesStock()
        {
            return Ok(_wineServices.GetAllWinesStock());
        }

        [HttpGet("{variety}")]
        public IActionResult GetWineStockByVariety([FromRoute] string variety) 
        {
            return Ok();
        }

        [HttpPut("update-stock/{wineId}")]
        public IActionResult UpdateStock(int wineId, [FromBody] int newStock)
        {
            _wineServices.UpdateWineStock(wineId, newStock);
            return NoContent();
        }
    }
}