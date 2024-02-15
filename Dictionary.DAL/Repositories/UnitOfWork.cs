using Dictionary.DAL.Interfaces;

namespace Dictionary.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly DictionaryContext databaseContext;
    public ITermRepository TermRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IUseFrequencyRepository UseFrequencyRepository { get; }

    public UnitOfWork(
        DictionaryContext databaseContext, 
        ITermRepository termRepository, 
        ICategoryRepository categoryRepository, 
        IUseFrequencyRepository useFrequencyRepository)
    {
        this.databaseContext = databaseContext;
        TermRepository = termRepository;
        CategoryRepository = categoryRepository;
        UseFrequencyRepository = useFrequencyRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}