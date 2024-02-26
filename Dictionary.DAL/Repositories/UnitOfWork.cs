using Dictionary.DAL.Interfaces;

namespace Dictionary.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DictionaryContext _databaseContext;
    public ITermRepository TermRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IUseFrequencyRepository UseFrequencyRepository { get; }

    public UnitOfWork(
        DictionaryContext databaseContext, 
        ITermRepository termRepository, 
        ICategoryRepository categoryRepository, 
        IUseFrequencyRepository useFrequencyRepository)
    {
        _databaseContext = databaseContext;
        TermRepository = termRepository;
        CategoryRepository = categoryRepository;
        UseFrequencyRepository = useFrequencyRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _databaseContext.SaveChangesAsync();
    }
}