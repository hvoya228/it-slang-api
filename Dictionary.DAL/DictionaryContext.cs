using System.Reflection;
using Dictionary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.DAL;

public class DictionaryContext : DbContext
{
    public DictionaryContext(DbContextOptions<DictionaryContext> options) : base(options) { }
    
    public DbSet<Term> Terms { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}