using Dictionary.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly DictionaryContext DatabaseContext;
    protected readonly DbSet<TEntity> Table;

    public GenericRepository(DictionaryContext databaseContext)
    {
        this.DatabaseContext = databaseContext;
        Table = this.DatabaseContext.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync() => await Table.ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(Guid id) => (await Table.FindAsync(id))!;

    public virtual async Task InsertAsync(TEntity entity) => await Table.AddAsync(entity);

    public virtual async Task UpdateAsync(TEntity entity) => await Task.Run(() => Table.Update(entity));

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        await Task.Run(() => Table.Remove(entity));
    }
}