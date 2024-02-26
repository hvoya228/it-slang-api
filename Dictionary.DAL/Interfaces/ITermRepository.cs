using Dictionary.Data.Models;

namespace Dictionary.DAL.Interfaces;

public interface ITermRepository : IGenericRepository<Term>
{
    Task<List<Term>> GetByTextAsync(string name);
    Task<List<Term>> GetByCategoryIdAsync(Guid categoryId);
}