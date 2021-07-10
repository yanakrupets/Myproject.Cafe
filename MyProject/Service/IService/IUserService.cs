using MyProject.EfStuff.Model;
using System.Security.Claims;

namespace MyProject.Service
{
    public interface IUserService
    {
        User GetCurrent();
        ClaimsPrincipal GetPrincipal(User user);
        void LangChange(Language lang);
    }
}