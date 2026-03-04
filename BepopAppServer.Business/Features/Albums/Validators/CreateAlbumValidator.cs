using BepopAppServer.Business.Features.Albums.DTOs;
using FluentValidation;

namespace BepopAppServer.Business.Features.Albums.Validators
{
    public class CreateAlbumValidator : AbstractValidator<CreateAlbumDto>
    {
        public CreateAlbumValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name boş olamaz");
        }
    }
}
