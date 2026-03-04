using BepopAppServer.Business.Features.Artists.DTOs;
using FluentValidation;

namespace BepopAppServer.Business.Features.Artists.Validators
{
    public class CreateArtistValidator : AbstractValidator<CreateArtistDto>
    {
        public CreateArtistValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz.")
                                .MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.")
                                .MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.");

            RuleFor(x => x.Country).MaximumLength(50).WithMessage("Ülke adı çok uzun.")
                                   .When(x => !string.IsNullOrEmpty(x.Country));
        }
    }
}
