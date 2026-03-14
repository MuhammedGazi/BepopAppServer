using BepopAppServer.Business.Features.Albums.DTOs;
using BepopAppServer.Business.Features.Albums.Services;
using Microsoft.AspNetCore.Mvc;

namespace BepopAppServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController(IAlbumService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var album = await _service.TGetAllAsync();
            return Ok(album);
        }

        [HttpGet("last4albumByArtist/{id}")]
        public async Task<IActionResult> GetLast4AlbumById(int id)
        {
            var album = await _service.GetLast4AlbumByArtistAsync(id);
            return Ok(album);
        }
        [HttpGet("allAlbumByArtist/{id}")]
        public async Task<IActionResult> GetAllAlbumByArtist(int id)
        {
            var album = await _service.GetAlbumByArtistAsync(id);
            return Ok(album);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var album = await _service.TGetByIdAsync(id);
            return Ok(album);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAlbumDto dto)
        {
            await _service.TCreateAsync(dto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAlbumDto dto)
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
