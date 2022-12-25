using UserServiceGateway.CommonBO;

namespace UserServiceGateway.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserBO>> GetAllUsers();
        Task<UserBO> GetUserById(int userId);
        Task<bool> DeleteUser(int userId);
    }
}
