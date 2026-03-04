using BepopAppServer.Business.Features.Artists.DTOs;
using BepopAppServer.Business.Features.Artists.Services;
using Microsoft.AspNetCore.Mvc;

namespace BepopAppServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController(IArtistService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artist = await _service.TGetAllAsync();
            return Ok(artist);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var artist = await _service.TGetByIdAsync(id);
            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArtistDto dto)
        {
            await _service.TCreateAsync(dto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateArtistDto dto)
        {
            await _service.TUpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.TDeleteAsync(id);
            return NoContent();
        }
    }
}
