using Challenge.Core.Entities;

namespace Challenge.Core.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int? id);
        Task AddAsync(Company company);
        Task SaveChangesAsync();
        Task RemoveAsync(Company company);
    }
}
