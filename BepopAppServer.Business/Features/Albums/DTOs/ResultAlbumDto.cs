using BepopAppServer.Entity.Entities;

namespace BepopAppServer.Business.Features.Albums.DTOs
{
    public record ResultAlbumDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? CoverImageUrl { get; init; }
        public int ContentLevel { get; init; } // Albümün gerektirdiği yetki seviyesi

        public int ArtistId { get; init; }
        public ResultAlbumDto Artist { get; init; }

        public List<Song> Songs { get; init; }
    }
}
