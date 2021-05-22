using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantTracker.Business.Abstract;
using RestaurantTracker.Entities;

namespace RestaurantTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestoransController : Controller
    {
        private IRestoranService _restoranService; 

        public RestoransController(IRestoranService restoranService)
        {
            _restoranService = restoranService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestorans()
        {
            var restorans = await _restoranService.GetAllRestorans();
            return Ok(restorans);   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var restoran = await _restoranService.GetById(id);

            if (restoran == null)
                return NotFound();

            return Ok(restoran);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestoran([FromBody]Restoran restoran)
        {
            var createdRestoran = await _restoranService.CreateRestoran(restoran);
            return CreatedAtAction("GetById", new { id = createdRestoran.Id }, createdRestoran);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestoran([FromBody]Restoran restoran)
        {
            var theRestoran = await _restoranService.GetById(restoran.Id);

            if (theRestoran == null)
                return NotFound();

            var updatedRestoran = await _restoranService.UpdateRestoran(restoran);
            return Ok(updatedRestoran);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestoran(int id)
        {
            var theRestoran = await _restoranService.GetById(id);

            if (theRestoran == null)
                return NotFound();

            var deletedRestoran = await _restoranService.DeleteRestoran(id);
            return Ok(deletedRestoran);
        }
    }
}