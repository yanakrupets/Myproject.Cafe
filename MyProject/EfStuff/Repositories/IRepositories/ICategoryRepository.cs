using MyProject.EfStuff.Model;

namespace MyProject.EfStuff.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Category Get(string name);
    }
}