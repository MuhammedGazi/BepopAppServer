using BepopAppServer.DAL.Context;
using BepopAppServer.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BepopAppServer.DAL.Repositories.AlbumRepositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly AppDbContext context;
        public AlbumRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<List<Album>> GetAlbumByArtistAsync(int artistId)
        {
            return await context.Set<Album>().Include(x => x.Artist)
                                             .OrderByDescending(x => x.Id)
                                             .Where(x => x.ArtistId == artistId)
                                             .ToListAsync();
        }

        public async Task<Album> GetByIdWithArtistAsync(int id)
        {
            return await context.Albums.Include(a => a.Songs)
                                        .ThenInclude(a => a.Category)
                                        .Include(a => a.Artist)
                                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Album>> GetLast4AlbumByArtistAsync(int artistId)
        {
            return await context.Set<Album>().Include(x => x.Artist)
                                             .OrderByDescending(x => x.Id)
                                             .Where(x => x.ArtistId == artistId)
                                             .Take(4).ToListAsync();
        }
    }
}
