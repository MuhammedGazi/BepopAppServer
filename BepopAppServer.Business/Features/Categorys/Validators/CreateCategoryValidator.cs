using BepopAppServer.Business.Features.Categorys.DTOs;
using FluentValidation;

namespace BepopAppServer.Business.Features.Categorys.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("kategori adı boş olamaz");
        }
    }
}
