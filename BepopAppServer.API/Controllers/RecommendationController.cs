using BepopAppServer.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BepopAppServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppDbContext _context;

        public RecommendationController(IHttpClientFactory httpClientFactory, AppDbContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserRecommendations(string userId)
        {
            var client = _httpClientFactory.CreateClient();
            var pythonApiUrl = $"http://localhost:8080/recommend/{userId}";

            try
            {
                var response = await client.GetAsync(pythonApiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest("Öneri motoruna ulaşılamadı.");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var recommendationData = JsonSerializer.Deserialize<PythonResponseDto>(jsonString, options);

                if (recommendationData?.RecommendedSongIds == null || !recommendationData.RecommendedSongIds.Any())
                {
                    return Ok(new { Message = "Sistemde yeterli veri yok veya önerecek yeni şarkı kalmadı." });
                }

                var recommendedIds = recommendationData.RecommendedSongIds;
                var songsFromDb = await _context.Songs
                    .Include(s => s.Artist)
                    .Include(s => s.Album)
                    .Include(s => s.Category)
                    .Where(s => recommendedIds.Contains(s.Id))
                    .ToListAsync();


                var orderedSongs = recommendedIds
                    .Select(id => songsFromDb.FirstOrDefault(s => s.Id == id))
                    .Where(s => s != null)
                    .Select(s => new
                    {
                        Id = s.Id,
                        Title = s.Title,
                        AudioUrl = s.AudioUrl,
                        CoverImageUrl = s.CoverImageUrl,
                        ContentLevel = s.ContentLevel,
                        ArtistName = s.Artist != null ? s.Artist.Name : "Bilinmeyen Sanatçı",
                        AlbumName = s.Album != null ? s.Album.Name : null,
                        CategoryName = s.Category != null ? s.Category.Name : null
                    })
                    .ToList();

                return Ok(orderedSongs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }

    public class PythonResponseDto
    {
        public string UserId { get; set; }
        public List<int> RecommendedSongIds { get; set; }
        public string Message { get; set; }
    }
}
