using Dictionary.DAL.Interfaces;
using Dictionary.Data.Models;

namespace Dictionary.DAL.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DictionaryContext databaseContext) : base(databaseContext)
    {
    }
}