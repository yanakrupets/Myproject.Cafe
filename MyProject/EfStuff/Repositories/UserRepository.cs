using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CafeDbContext cafeDbContext) : base(cafeDbContext) 
        { 
        }

        public User Get(string name)
        {
            return _dbSet.SingleOrDefault(x =>
                x.Name.ToLower() == name.ToLower()
                || x.Login.ToLower() == name.ToLower());
        }
    }
}
