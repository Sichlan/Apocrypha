using Apocrypha.CommonObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apocrypha.EntityFramework.Configurations;

public class AllignmentConfiguration : IEntityTypeConfiguration<Allignment>
{
    public void Configure(EntityTypeBuilder<Allignment> builder)
    {
        builder.Ignore(x => x.Name);
        //builder.HasMany(x => x.Translations).WithOne()
    }
}