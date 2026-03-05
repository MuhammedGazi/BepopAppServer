using BepopAppServer.Business.Features.Songs.DTOs;
using FluentValidation;

namespace BepopAppServer.Business.Features.Songs.Validators
{
    public class UpdateSongValidator : AbstractValidator<UpdateSongDto>
    {
        public UpdateSongValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("title boş olamaz");
        }
    }
}
