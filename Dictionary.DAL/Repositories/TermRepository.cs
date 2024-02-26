using Dictionary.DAL.Interfaces;
using Dictionary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.DAL.Repositories;

public class TermRepository : GenericRepository<Term>, ITermRepository 
{
    public TermRepository(DictionaryContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<List<Term>> GetByTextAsync(string text)
    {
        return await Table.Where(x => x.Text.Contains(text)).ToListAsync();
    }
    
    public async Task<List<Term>> GetByCategoryIdAsync(Guid categoryId)
    {
        return await Table.Where(x => x.CategoryId == categoryId).ToListAsync();
    }
}