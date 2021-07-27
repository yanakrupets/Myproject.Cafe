using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CafeDbContext cafeDbContext) : base(cafeDbContext)
        {
        }

        public Category Get(string name)
        {
            return _dbSet.SingleOrDefault(x =>
                x.Name.ToLower() == name.ToLower());
        }
    }
}
