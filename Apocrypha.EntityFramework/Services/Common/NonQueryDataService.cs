using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : DatabaseObject
    {
        protected readonly ApocryphaDbContextFactory _dbContextFactory;

        public NonQueryDataService(ApocryphaDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var createdEntity = context.Set<T>().Add(entity);
                _ = await context.SaveChangesAsync();

                return createdEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entityToDelete = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                _ = context.Set<T>().Remove(entityToDelete);

                _ = await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}