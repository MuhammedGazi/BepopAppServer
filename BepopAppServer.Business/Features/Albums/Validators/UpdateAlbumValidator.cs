using BepopAppServer.Business.Features.Albums.DTOs;
using FluentValidation;

namespace BepopAppServer.Business.Features.Albums.Validators
{
    public class UpdateAlbumValidator : AbstractValidator<UpdateAlbumDto>
    {
        public UpdateAlbumValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name boş olamaz");
        }
    }
}
