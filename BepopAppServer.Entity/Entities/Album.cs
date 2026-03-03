using BepopAppServer.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BepopAppServer.Entity.Entities
{
    public class Album:BaseEntity
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
            this.Songs.Add(song);
        }
    }
}
