using BepopAppServer.Entity.Entities;

namespace BepopAppServer.DAL.Repositories.SongRepositories
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<List<Song>> Last5SongAsync();
        Task<List<Song>> Last5SongByArtistAsync(int artistId);
        Task<List<Song>> GetSongByArtistAsync(int artistId);
    }
}
