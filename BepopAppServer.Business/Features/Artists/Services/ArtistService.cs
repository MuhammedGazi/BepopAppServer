using BepopAppServer.Business.Features.Artists.DTOs;
using BepopAppServer.DAL.Repositories;
using BepopAppServer.DAL.UOF;
using BepopAppServer.Entity.Entities;
using Mapster;

namespace BepopAppServer.Business.Features.Artists.Services
{
    public class ArtistService(IRepository<Artist> _repository,
                               IUnitOfWork _unitOfWork) : IArtistService
    {
        public async Task TCreateAsync(CreateArtistDto createDto)
        {
            var category = createDto.Adapt<Artist>();
            await _repository.CreateAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var artist = await _repository.GetByIdAsync(id);
            if (artist is null)
                throw new Exception("category bulunamadı");
            _repository.Delete(artist);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultArtistDto>> TGetAllAsync()
        {
            var artists = await _repository.GetAllAsync();
            return artists.Adapt<List<ResultArtistDto>>();
        }

        public async Task<UpdateArtistDto> TGetByIdAsync(int id)
        {
            var artist = await _repository.GetByIdAsync(id);
            if (artist is null)
                throw new Exception("category bulunamadı");
            return artist.Adapt<UpdateArtistDto>();
        }

        public async Task TUpdateAsync(UpdateArtistDto updateDto)
        {
            var artist = await _repository.GetByIdAsync(updateDto.Id);
            if (artist is null)
                throw new Exception("category bulunamadı");
            updateDto.Adapt(artist);
            _repository.Update(artist);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
