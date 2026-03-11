using BepopAppServer.DAL.Context;
using BepopAppServer.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BepopAppServer.DAL.Repositories.SongRepositories
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        private readonly AppDbContext context;
        public SongRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<List<Song>> Last5SongAsync()
        {
            return await context.Set<Song>().Include(x => x.Category)
                                            .Include(x => x.Artist)
                                            .Include(x => x.Album)
                                            .OrderByDescending(x => x.Id)
                                            .Take(5).ToListAsync();
        }
    }
}
