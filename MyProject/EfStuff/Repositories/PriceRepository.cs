using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Repositories
{
    public class PriceRepository : BaseRepository<Price>, IPriceRepository
    {
        public PriceRepository(CafeDbContext cafeDbContext) : base(cafeDbContext)
        {
        }
    }
}
