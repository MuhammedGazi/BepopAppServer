using Microsoft.AspNetCore.Identity;

namespace BepopAppServer.Entity.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageUrl { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }

        public IList<UserSongHistory> SongHistories { get; set; }
    }
}
