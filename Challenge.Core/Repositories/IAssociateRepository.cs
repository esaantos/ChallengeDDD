using Challenge.Core.Entities;

namespace Challenge.Core.Repositories
{
    public interface IAssociateRepository
    {
        Task<List<Associate>> GetAllAsync();
        Task<Associate> GetByIdAsync(int? id);
        Task AddAsync(Associate associate);
        Task SaveChangesAsync();
        Task RemoveAsync(Associate associate);
    }
}
