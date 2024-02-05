using Challenge.Core.Entities;
using Challenge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Persistence.Repositories
{
    public class AssociateRepository : IAssociateRepository
    {
        private readonly AppDbContext _context;

        public AssociateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Associate>> GetAllAsync()
        {
            return await _context.Associates
                .Include(a => a.Companies)
                .ToListAsync();
        }

        public async Task<Associate> GetByIdAsync(int? id)
        {
            return await _context.Associates
                .Include(c => c.Companies)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAsync(Associate associate)
        {
            await _context.Associates.AddAsync(associate);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Associate associate)
        {
            _context.Associates.Remove(associate);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Associate associate)
        {
            _context.Remove(associate);
            await _context.SaveChangesAsync();
        }
    }
}
