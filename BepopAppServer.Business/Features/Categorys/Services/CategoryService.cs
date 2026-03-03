using BepopAppServer.Business.Features.Categorys.DTOs;
using BepopAppServer.DAL.Repositories;
using BepopAppServer.DAL.UOF;
using BepopAppServer.Entity.Entities;
using Mapster;

namespace BepopAppServer.Business.Features.Categorys.Services
{
    public class CategoryService(IRepository<Category> _repository,
                                 IUnitOfWork _unitOfWork) : ICategoryService
    {
        public async Task TCreateAsync(CreateCategoryDto dto)
        {
            var category = dto.Adapt<Category>();
            await _repository.CreateAsync(category);
            await _unitOfWork.SaveChangesAsync(); 
        }

        public async Task TDeleteAsync(int id)
        {
            var category=await _repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("category bulunamadı");
            }
            _repository.DeleteAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultCategoryDto>> TGetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Adapt<List<ResultCategoryDto>>();
        }

        public async Task<UpdateCategoryDto> TGetByIdAsync(int id)
        {
            var category=await _repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("category bulunamadı");
            }
            return category.Adapt<UpdateCategoryDto>();
        }

        public async Task TUpdateAsync(UpdateCategoryDto dto)
        {
            var category = dto.Adapt<Category>();
            _repository.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
