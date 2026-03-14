using BepopAppServer.Business.Features.Songs.DTOs;
using BepopAppServer.Business.Features.UserSongHistorys.DTOs;
using BepopAppServer.Business.Features.UserSongHistorys.Services;
using BepopAppServer.DAL.Repositories.SongRepositories;
using BepopAppServer.DAL.UOF;
using BepopAppServer.Entity.Entities;
using Mapster;

namespace BepopAppServer.Business.Features.Songs.Services
{
    public class SongService(ISongRepository _repository,
                             IUnitOfWork _unitOfWork,
                             IUserSongHistoryService _userSongHistoryService) : ISongService
    {
        public async Task<List<ResultSongDto>> GetSongByArtistAsync(int artistId)
        {
            var songs = await _repository.GetSongByArtistAsync(artistId);
            return songs.Adapt<List<ResultSongDto>>();
        }

        public async Task<List<ResultSongDto>> Last5SongAsync()
        {
            var songs = await _repository.Last5SongAsync();
            return songs.Adapt<List<ResultSongDto>>();
        }

        public async Task<List<ResultSongDto>> Last5SongByArtistAsync(int artistId)
        {
            var songs = await _repository.Last5SongByArtistAsync(artistId);
            return songs.Adapt<List<ResultSongDto>>();
        }

        public async Task<ResultSongDto> PlaySongAsync(int songId, string userId)
        {
            var song = await GetSongByIdOrThrowAsync(songId);
            var songHistory = new CreateUserSongHistoryDto
            {
                AppUserId = userId,
                SongId = song.Id,
            };
            await _userSongHistoryService.TCreateAsync(songHistory);
            return song.Adapt<ResultSongDto>();
        }

        public async Task TCreateAsync(CreateSongDto createDto)
        {
            var song = createDto.Adapt<Song>();
            await _repository.CreateAsync(song);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var song = await GetSongByIdOrThrowAsync(id);
            _repository.Delete(song);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultSongDto>> TGetAllAsync()
        {
            var songs = await _repository.GetAllAsync(q => q.Category, p => p.Artist, p => p.Album);
            return songs.Adapt<List<ResultSongDto>>();
        }

        public async Task<UpdateSongDto> TGetByIdAsync(int id)
        {
            var song = await GetSongByIdOrThrowAsync(id);
            return song.Adapt<UpdateSongDto>();
        }

        public async Task TUpdateAsync(UpdateSongDto updateDto)
        {
            var song = await GetSongByIdOrThrowAsync(updateDto.Id);
            updateDto.Adapt(song);
            _repository.Update(song);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<Song> GetSongByIdOrThrowAsync(int id)
        {
            var song = await _repository.GetByIdAsync(id);
            if (song is null)
            {
                throw new Exception("Song Bulunamadı");
            }
            return song;
        }
    }
}
