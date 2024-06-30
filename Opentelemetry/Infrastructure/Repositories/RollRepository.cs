

using Roller.Domain.Entities;
using Roller.Infrastructure.Database;
using Roller.Appication.ContractRepo;
using Microsoft.EntityFrameworkCore;

namespace Roller.Infrastructure.Repositories
{
    public class RollRepository : IRollRepository
    {
        private readonly DataContext _context;

        public RollRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Roll> GetRollByIdAsync(int id)
        {
            return await _context.Rolls.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Roll>> GetRollsAsync()
        {
            return await _context.Rolls.ToListAsync();
        }

        public async Task<Roll> CreateRollAsync(Roll roll)
        {
            await _context.Rolls.AddAsync(roll);
            await _context.SaveChangesAsync();
            return roll;
        }

    }
}