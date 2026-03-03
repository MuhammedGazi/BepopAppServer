using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BepopAppServer.Business.Features.GenericServices
{
    public interface IGenericService<TResultDto, TCreateDto, TUpdateDto>
    {
        Task<List<TResultDto>> TGetAllAsync();
        Task<TUpdateDto> TGetByIdAsync(int id);
        Task TCreateAsync(TCreateDto createDto);
        Task TUpdateAsync(TUpdateDto updateDto);
        Task TDeleteAsync(int id);
    }
}
