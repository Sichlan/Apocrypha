using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services
{
    public class CreatureSizeCategoryDataService : IDataService<CreatureSizeCategory>, IDefaultIncludes<CreatureSizeCategory>
    {
        private readonly ApocryphaDbContextFactory _contextFactory;
        private readonly NonQueryDataService<CreatureSizeCategory> _nonQueryDataService;

        public CreatureSizeCategoryDataService(ApocryphaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<CreatureSizeCategory>(contextFactory);
        }

        public async Task<IEnumerable<CreatureSizeCategory>> GetAll()
        {
            return await GetAllWhere(x => true);
        }

        public async Task<IEnumerable<CreatureSizeCategory>> GetAllWhere(Expression<Func<CreatureSizeCategory, bool>> predicate)
        {
            using var context = _contextFactory.CreateDbContext();

            IEnumerable<CreatureSizeCategory> entities = await GetDefaultIncludes(context)
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        public async Task<CreatureSizeCategory> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var creatureSizeCategory = await GetDefaultIncludes(context)
                .FirstOrDefaultAsync(x => x.Id == id);

            return creatureSizeCategory;
        }

        public async Task<CreatureSizeCategory> Create(CreatureSizeCategory entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<CreatureSizeCategory> Update(int id, CreatureSizeCategory entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public IIncludableQueryable<CreatureSizeCategory, object> GetDefaultIncludes(ApocryphaDbContext context)
        {
            return context.CreatureSizeCategories.AsNoTracking()
                .Include(x => x.CreatureSizeCategoryTranslations);
        }
    }
}