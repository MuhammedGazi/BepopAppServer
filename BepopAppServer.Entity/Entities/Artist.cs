using BepopAppServer.Entity.Entities.Common;

namespace BepopAppServer.Entity.Entities
{
    public class Artist : BaseEntity
    {
        public string Name { get; set; }
        public string? Country { get; set; }
        public string? ProfileImageUrl { get; set; }

        public IList<Album> Albums { get; set; }
        public IList<Song> Songs { get; set; }
    }
}
