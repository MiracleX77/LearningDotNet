using Roller.Domain.Entities;

namespace Roller.Appication.ContractRepo
{
    public interface IRollRepository
    {
        Task<Roll> GetRollByIdAsync(int id);
        Task<List<Roll>> GetRollsAsync();
        Task<Roll> CreateRollAsync(Roll roll);
    }
}