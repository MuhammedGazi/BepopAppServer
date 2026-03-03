using BepopAppServer.Business.Features.Categorys.DTOs;
using BepopAppServer.Business.Features.GenericServices;

namespace BepopAppServer.Business.Features.Categorys.Services
{
    public interface ICategoryService : IGenericService<ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
    }
}
