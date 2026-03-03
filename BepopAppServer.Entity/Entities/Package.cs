using BepopAppServer.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BepopAppServer.Entity.Entities
{
    public class Package:BaseEntity
    {
        public string Name { get; set; }
        public int MaxAccessLevel { get; set; }

        public IList<AppUser> Users { get; set; }
    }
}
