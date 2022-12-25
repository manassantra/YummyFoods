using YummyFood.Web.CommonBO;

namespace YummyFood.Web.Interfaces
{
    public interface IUserService
    {
        Task<T> GetUserById<T>(int userId, string token);
    }
}
