using BepopAppServer.Business.Features.Albums.DTOs;
using BepopAppServer.DAL.Repositories.AlbumRepositories;
using BepopAppServer.DAL.UOF;
using BepopAppServer.Entity.Entities;
using Mapster;

namespace BepopAppServer.Business.Features.Albums.Services
{
    public class AlbumService(IAlbumRepository _repository,
                              IUnitOfWork _unitOfWork) : IAlbumService
    {
        public async Task<List<ResultAlbumDto>> GetAlbumByArtistAsync(int artistId)
        {
            var albums = await _repository.GetAlbumByArtistAsync(artistId);
            return albums.Adapt<List<ResultAlbumDto>>();
        }

        public async Task<List<ResultAlbumDto>> GetLast4AlbumByArtistAsync(int artistId)
        {
            var albums = await _repository.GetLast4AlbumByArtistAsync(artistId);
            return albums.Adapt<List<ResultAlbumDto>>();
        }

        public async Task TCreateAsync(CreateAlbumDto createDto)
        {
            var album = new Album
            {
                Name = createDto.Name,
                CoverImageUrl = createDto.CoverImageUrl,
                ContentLevel = createDto.ContentLevel,
                ArtistId = createDto.ArtistId
            };

            if (createDto.Songs != null)
            {
                foreach (var songDto in createDto.Songs)
                {
                    var song = songDto.Adapt<Song>();
                    album.AddSong(song);
                }
            }
            await _repository.CreateAsync(album);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var album = await GetAlbumByIdOrThrowAsync(id);
            _repository.Delete(album);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultAlbumDto>> TGetAllAsync()
        {
            var albums = await _repository.GetAllAsync(q => q.Artist);
            return albums.Adapt<List<ResultAlbumDto>>();
        }

        public async Task<UpdateAlbumDto> TGetByIdAsync(int id)
        {
            var album = await GetAlbumByIdOrThrowAsync(id);
            return album.Adapt<UpdateAlbumDto>();
        }

        public async Task TUpdateAsync(UpdateAlbumDto updateDto)
        {
            var album = await GetAlbumByIdOrThrowAsync(updateDto.Id);
            updateDto.Adapt(album);
            _repository.Update(album);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<Album> GetAlbumByIdOrThrowAsync(int id)
        {
            var album = await _repository.GetByIdAsync(id);
            if (album is null)
                throw new Exception("Album Bulunamadı");
            return album;
        }
    }
}
