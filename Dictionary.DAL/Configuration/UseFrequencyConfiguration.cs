using Dictionary.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionary.DAL.Configuration;

public class UseFrequencyConfiguration : IEntityTypeConfiguration<UseFrequency>
{
    public void Configure(EntityTypeBuilder<UseFrequency> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder
            .Property(m => m.Frequency)
            .IsRequired();
    }
}