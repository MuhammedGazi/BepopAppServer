using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BepopAppServer.Business.Features.Albums.DTOs
{
    public record CreateSongForAlbumDto
    {
        public string Title { get; init; }
        public string AudioUrl { get; init; }
        public int? CategoryId { get; init; }
    }
}
