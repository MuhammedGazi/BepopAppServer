using BepopAppServer.Entity.Entities;

namespace BepopAppServer.Business.Features.Albums.DTOs
{
    public class UpdateAlbumDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CoverImageUrl { get; set; }
        public int ContentLevel { get; set; } // Albümün gerektirdiği yetki seviyesi

        public int ArtistId { get; set; }
        public ResultAlbumDto Artist { get; set; }

        public List<Song> Songs { get; set; }
    }
}
