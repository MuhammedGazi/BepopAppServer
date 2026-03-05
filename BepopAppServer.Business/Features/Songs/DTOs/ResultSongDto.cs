using BepopAppServer.Business.Features.Albums.DTOs;
using BepopAppServer.Business.Features.Artists.DTOs;
using BepopAppServer.Business.Features.Categorys.DTOs;

namespace BepopAppServer.Business.Features.Songs.DTOs
{
    public record ResultSongDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string AudioUrl { get; init; }
        public int ContentLevel { get; init; }

        public int? AlbumId { get; init; }
        public ResultAlbumDto? Album { get; init; }

        public int? CategoryId { get; init; }
        public ResultCategoryDto? Category { get; init; }

        public int? ArtistId { get; init; }
        public ResultArtistDto? Artist { get; init; }
    }
}
