using BepopAppServer.Business.Features.GenericServices;
using BepopAppServer.Business.Features.Songs.DTOs;

namespace BepopAppServer.Business.Features.Songs.Services
{
    public interface ISongService : IGenericService<ResultSongDto, CreateSongDto, UpdateSongDto>
    {
        Task<ResultSongDto> PlaySongAsync(int songId, string userId);
        Task<List<ResultSongDto>> Last5SongAsync();
        Task<List<ResultSongDto>> Last5SongByArtistAsync(int artistId);
        Task<List<ResultSongDto>> GetSongByArtistAsync(int artistId);
    }
}
