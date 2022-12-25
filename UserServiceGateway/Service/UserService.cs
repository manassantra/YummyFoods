using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserServiceGateway.CommonBO;
using UserServiceGateway.DbContexts;
using UserServiceGateway.Models;
using UserServiceGateway.Service.Interface;

namespace UserServiceGateway.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContexts;
        private IMapper _mapper;
        public UserService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContexts = dbContext;
            _mapper = mapper;  
        }

        public async Task<UserBO> GetUserById(int userId)
        {
            User user = await _dbContexts.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            return _mapper.Map<UserBO>(user);
        }

        public async Task<IEnumerable<UserBO>> GetAllUsers()
        {
            List<User> users = await _dbContexts.Users.ToListAsync();
            return _mapper.Map<List<UserBO>>(users);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            User user = await _dbContexts.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                return false;
            }
            _dbContexts.Users.Remove(user);
            await _dbContexts.SaveChangesAsync();
            return true;
        }
    }
}
