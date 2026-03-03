namespace BepopAppServer.Business.Features.Categorys.DTOs
{
    public record UpdateCategoryDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
