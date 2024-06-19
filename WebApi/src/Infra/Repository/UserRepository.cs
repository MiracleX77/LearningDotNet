using WebApi.src.Entities;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.src.Infra {
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;

        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public async Task<User> GetUserById(decimal id)
        {
            try {
                if (id == 0) {
                    throw new Exception("Id is null");
                }
                var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null) {
                    throw new Exception("User not found");
                }
                return user;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public async Task AddUser(User user)
        {
            try {
                await _dbContext.User.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
            
        }
    }
}