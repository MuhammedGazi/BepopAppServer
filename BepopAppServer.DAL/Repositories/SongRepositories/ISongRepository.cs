using BepopAppServer.Entity.Entities;

namespace BepopAppServer.DAL.Repositories.SongRepositories
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<List<Song>> Last5SongAsync();
    }
}
