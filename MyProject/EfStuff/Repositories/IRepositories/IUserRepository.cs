using MyProject.EfStuff.Model;

namespace MyProject.EfStuff.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(string name);
    }
}