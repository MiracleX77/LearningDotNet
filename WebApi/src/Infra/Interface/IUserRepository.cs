using WebApi.src.Entities;

namespace WebApi.src.Infra
{
    public interface IUserRepository
    {
        Task<User> GetUserById(decimal id);
        Task  AddUser(User user);
    }
}