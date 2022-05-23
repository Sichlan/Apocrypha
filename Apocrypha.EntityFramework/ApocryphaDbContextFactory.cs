using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Apocrypha.EntityFramework
{
    public class ApocryphaDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public ApocryphaDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public ApocryphaDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApocryphaDbContext>();

            _configureDbContext(options);

            return new ApocryphaDbContext(options.Options);
        }
    }
}