using BepopAppServer.Business.Features.Albums.DTOs;
using BepopAppServer.Business.Features.GenericServices;

namespace BepopAppServer.Business.Features.Albums.Services
{
    public interface IAlbumService : IGenericService<ResultAlbumDto, CreateAlbumDto, UpdateAlbumDto>
    {
        Task<List<ResultAlbumDto>> GetLast4AlbumByArtistAsync(int artistId);
        Task<List<ResultAlbumDto>> GetAlbumByArtistAsync(int artistId);
    }
}
