using BepopAppServer.Business.Features.GenericServices;
using BepopAppServer.Business.Features.Songs.DTOs;

namespace BepopAppServer.Business.Features.Songs.Services
{
    public interface ISongService : IGenericService<ResultSongDto, CreateSongDto, UpdateSongDto>
    {
    }
}
