using BepopAppServer.Business.Features.Artists.DTOs;
using BepopAppServer.Business.Features.GenericServices;

namespace BepopAppServer.Business.Features.Artists.Services
{
    public interface IArtistService : IGenericService<ResultArtistDto, CreateArtistDto, UpdateArtistDto>
    {
    }
}
