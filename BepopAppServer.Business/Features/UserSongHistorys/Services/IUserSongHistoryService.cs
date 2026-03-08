using BepopAppServer.Business.Features.GenericServices;
using BepopAppServer.Business.Features.UserSongHistorys.DTOs;

namespace BepopAppServer.Business.Features.UserSongHistorys.Services
{
    public interface IUserSongHistoryService : IGenericService<ResultUserSongHistoryDto, CreateUserSongHistoryDto, UpdateUserSongHistoryDto>
    {
    }
}
