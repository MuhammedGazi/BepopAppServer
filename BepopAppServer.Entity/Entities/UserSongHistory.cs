using BepopAppServer.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BepopAppServer.Entity.Entities
{
    public class UserSongHistory:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser User { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }

        public DateTime ListenedAt { get; set; } = DateTime.UtcNow;
    }
}
