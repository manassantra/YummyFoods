using YummyFood.Web.CommonBO;
using YummyFood.Web.Models;

namespace YummyFood.Web.Interfaces
{
    public interface IAuthService
    {
        Task<T> Login<T>(LoginBO loginBo);
        Task<T> Signup<T>(SignupBO signupBo);
    }
}
