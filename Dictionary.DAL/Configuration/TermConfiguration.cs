using Dictionary.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionary.DAL.Configuration;

public class TermConfiguration : IEntityTypeConfiguration<Term>
{
    public void Configure(EntityTypeBuilder<Term> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder
            .Property(m => m.Text)
            .IsRequired();

        builder
            .Property(m => m.Explanation)
            .IsRequired();
        
        builder
            .Property(m => m.UsingExample)
            .IsRequired();
        
        builder
            .HasOne(m => m.Category)
            .WithMany(o => o.Terms)
            .HasForeignKey(m => m.CategoryId);
    }
}