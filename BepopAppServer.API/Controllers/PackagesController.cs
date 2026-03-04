using BepopAppServer.Business.Features.Packages.DTOs;
using BepopAppServer.Business.Features.Packages.Services;
using Microsoft.AspNetCore.Mvc;

namespace BepopAppServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController(IPackageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var package = await _service.TGetAllAsync();
            return Ok(package);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var package = await _service.TGetByIdAsync(id);
            return Ok(package);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePackageDto dto)
        {
            await _service.TCreateAsync(dto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePackageDto dto)
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
