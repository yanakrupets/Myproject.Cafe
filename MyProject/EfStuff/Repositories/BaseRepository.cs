using Microsoft.EntityFrameworkCore;
using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Repositories
{
    public abstract class BaseRepository<ModelType> 
        : IBaseRepository<ModelType> where ModelType : BaseModel
    {
        protected CafeDbContext _cafeDbContext;
        protected DbSet<ModelType> _dbSet;

        public BaseRepository(CafeDbContext cafeDbContext)
        {
            _cafeDbContext = cafeDbContext;
            _dbSet = _cafeDbContext.Set<ModelType>();
        }

        public virtual ModelType Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public virtual List<ModelType> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Save(ModelType model)
        {
            if (model.Id > 0)
            {
                _dbSet.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }
            _cafeDbContext.SaveChanges();
        }
    }
}
