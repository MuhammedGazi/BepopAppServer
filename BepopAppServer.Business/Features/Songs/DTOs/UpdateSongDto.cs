namespace BepopAppServer.Business.Features.Songs.DTOs
{
    public record UpdateSongDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string AudioUrl { get; init; }
        public int ContentLevel { get; init; }
        public int? AlbumId { get; init; }
        public int? CategoryId { get; init; }
        public int ArtistId { get; init; }
    }
}
