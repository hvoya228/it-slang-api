namespace Dictionary.DAL.Interfaces;

public interface IUnitOfWork
{
    ITermRepository TermRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task SaveChangesAsync();
}