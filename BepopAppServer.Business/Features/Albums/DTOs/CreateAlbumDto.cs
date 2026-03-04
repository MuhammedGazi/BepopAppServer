namespace BepopAppServer.Business.Features.Albums.DTOs
{
    public record CreateAlbumDto
    {
        public string? Name { get; init; }
        public string? CoverImageUrl { get; init; }
        public int ContentLevel { get; init; } // Albümün gerektirdiği yetki seviyesi
        public int ArtistId { get; init; }
        public List<CreateSongForAlbumDto>? Songs { get; init; }
    }
}
