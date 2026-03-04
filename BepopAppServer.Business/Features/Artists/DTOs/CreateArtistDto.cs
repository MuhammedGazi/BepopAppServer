namespace BepopAppServer.Business.Features.Artists.DTOs;

public record CreateArtistDto
{
    public string Name { get; init; }
    public string? Country { get; init; }
    public string? ProfileImageUrl { get; init; }
}
