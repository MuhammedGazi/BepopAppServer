using BepopAppServer.Business.Features.Categorys.DTOs;
using FluentValidation;

namespace BepopAppServer.Business.Features.Categorys.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("kategori adı boş olamaz");
        }
    }
}
