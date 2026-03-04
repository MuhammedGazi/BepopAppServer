using BepopAppServer.Entity.Entities.Common;

namespace BepopAppServer.Entity.Entities
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }
        public string? CoverImageUrl { get; set; }
        public int ContentLevel { get; set; } // Albümün gerektirdiği yetki seviyesi

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public List<Song> Songs { get; private set; } = new List<Song>();

        public void AddSong(Song song)
        {
            song.ContentLevel = this.ContentLevel;
            song.ArtistId = this.ArtistId;
            this.Songs.Add(song);
        }
    }
}
