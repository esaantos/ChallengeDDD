using Challenge.Core.Entities;
using Challenge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies
                .Include(c => c.Associates)
                .ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int? id)
        {
            return await _context.Companies
                .Include(a => a.Associates)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Company company)
        {
            await _context.AddAsync(company);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(Company company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
