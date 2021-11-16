using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework
{
    public class ApocryphaDbContextFactory
    {
        private readonly string _connectionString;

        public ApocryphaDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApocryphaDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<ApocryphaDbContext>();
            options.UseMySQL(_connectionString);

            return new ApocryphaDbContext(options.Options);
        }
    }
}