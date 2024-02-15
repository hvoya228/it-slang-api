using Dictionary.DAL.Interfaces;
using Dictionary.Data.Models;

namespace Dictionary.DAL.Repositories;

public class TermRepository : GenericRepository<Term>, ITermRepository 
{
    public TermRepository(DictionaryContext databaseContext) : base(databaseContext)
    {
    }
}