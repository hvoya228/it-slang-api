using Dictionary.DAL.Interfaces;

namespace Dictionary.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DictionaryContext _databaseContext;
    public ITermRepository TermRepository { get; }
    public ICategoryRepository CategoryRepository { get; }

    public UnitOfWork(
        DictionaryContext databaseContext, 
        ITermRepository termRepository, 
        ICategoryRepository categoryRepository)
    {
        _databaseContext = databaseContext;
        TermRepository = termRepository;
        CategoryRepository = categoryRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _databaseContext.SaveChangesAsync();
    }
}