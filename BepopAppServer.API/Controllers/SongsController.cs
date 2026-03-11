using BepopAppServer.Business.Features.Songs.DTOs;
using BepopAppServer.Business.Features.Songs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BepopAppServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController(ISongService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var song = await _service.TGetAllAsync();
            return Ok(song);
        }

        [HttpGet("last5songs")]
        public async Task<IActionResult> GetLast5Song()
        {
            var song = await _service.Last5SongAsync();
            return Ok(song);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var song = await _service.TGetByIdAsync(id);
            return Ok(song);
        }

        [HttpGet("{id}/play")]
        [Authorize]
        public async Task<IActionResult> PlaySong(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(currentUserId))
            {
                return Unauthorized("Kullanıcı kimliği doğrulanamadı.");
            }
            var result = await _service.PlaySongAsync(id, currentUserId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSongDto dto)
        {
            await _service.TCreateAsync(dto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSongDto dto)
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
