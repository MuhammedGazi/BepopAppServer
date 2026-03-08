using BepopAppServer.Business.Features.Songs.DTOs;
using BepopAppServer.Entity.Entities;

namespace BepopAppServer.Business.Features.UserSongHistorys.DTOs
{
    public class ResultUserSongHistoryDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser User { get; set; }

        public int SongId { get; set; }
        public ResultSongDto Song { get; set; }
    }
}
