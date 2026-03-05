using BepopAppServer.Entity.Entities.Common;

namespace BepopAppServer.Entity.Entities
{
    public class Song : BaseEntity
    {
        public string Title { get; set; }
        public string AudioUrl { get; set; }
        public int ContentLevel { get; set; }

        public int? AlbumId { get; set; }
        public virtual Album? Album { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public IList<UserSongHistory> Histories { get; set; }
    }
}
