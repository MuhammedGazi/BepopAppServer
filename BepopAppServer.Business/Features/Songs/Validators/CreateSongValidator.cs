using BepopAppServer.Business.Features.Songs.DTOs;
using FluentValidation;

namespace BepopAppServer.Business.Features.Songs.Validators
{
    public class CreateSongValidator : AbstractValidator<CreateSongDto>
    {
        public CreateSongValidator()
        {

        }
    }
}
