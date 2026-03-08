using BepopAppServer.Business.Features.UserSongHistorys.DTOs;
using BepopAppServer.DAL.Repositories;
using BepopAppServer.DAL.UOF;
using BepopAppServer.Entity.Entities;
using Mapster;

namespace BepopAppServer.Business.Features.UserSongHistorys.Services
{
    public class UserSongHistoryService(IRepository<UserSongHistory> _repository,
                                        IUnitOfWork _unitOfWork) : IUserSongHistoryService
    {
        public async Task TCreateAsync(CreateUserSongHistoryDto createDto)
        {
            var songHistory = createDto.Adapt<UserSongHistory>();
            await _repository.CreateAsync(songHistory);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var songHistory = await GetUserSongHistoryByIdOrThrow(id);
            _repository.Delete(songHistory);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultUserSongHistoryDto>> TGetAllAsync()
        {
            var songHistory = await _repository.GetAllAsync();
            return songHistory.Adapt<List<ResultUserSongHistoryDto>>();
        }

        public async Task<UpdateUserSongHistoryDto> TGetByIdAsync(int id)
        {
            var songHistory = await GetUserSongHistoryByIdOrThrow(id);
            return songHistory.Adapt<UpdateUserSongHistoryDto>();
        }

        public Task TUpdateAsync(UpdateUserSongHistoryDto updateDto)
        {
            throw new NotImplementedException();
        }

        private async Task<UserSongHistory> GetUserSongHistoryByIdOrThrow(int id)
        {
            var userSongHistory = await _repository.GetByIdAsync(id);
            if (userSongHistory == null)
            {
                throw new Exception("UserSongHistory bulunamadı");
            }
            return userSongHistory;
        }
    }
}
