using BepopAppServer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BepopAppServer.DAL.Repositories.AlbumRepositories
{
    public interface IAlbumRepository:IRepository<Album>
    {
        Task<List<Album>> GetLast4AlbumByArtistAsync(int artistId);
        Task<List<Album>> GetAlbumByArtistAsync(int artistId);
    }
}
