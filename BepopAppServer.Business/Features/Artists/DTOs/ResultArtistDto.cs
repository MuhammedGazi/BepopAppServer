namespace BepopAppServer.Business.Features.Artists.DTOs;

public record ResultArtistDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string? Country { get; init; }
    public string? ProfileImageUrl { get; init; }
}
