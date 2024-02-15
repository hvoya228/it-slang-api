using Dictionary.DAL.Interfaces;
using Dictionary.Data.Models;

namespace Dictionary.DAL.Repositories;

public class UseFrequencyRepository : GenericRepository<UseFrequency>, IUseFrequencyRepository
{
    public UseFrequencyRepository(DictionaryContext databaseContext) : base(databaseContext)
    {
    }
}