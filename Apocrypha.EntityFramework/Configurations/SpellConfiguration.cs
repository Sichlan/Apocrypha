using Apocrypha.CommonObject.Models.Spells;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apocrypha.EntityFramework.Configurations
{
    public class SpellConfiguration : IEntityTypeConfiguration<Spell>
    {
        public void Configure(EntityTypeBuilder<Spell> builder)
        {
            builder.Ignore(x => x.Name);
        }
    }
}