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
    public class CreatureSubTypeDataService : IDataService<CreatureSubType>, IDefaultIncludes<CreatureSubType>
    {
        private readonly ApocryphaDbContextFactory _contextFactory;
        private readonly NonQueryDataService<CreatureSubType> _nonQueryDataService;

        public CreatureSubTypeDataService(ApocryphaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<CreatureSubType>(contextFactory);
        }

        public async Task<IEnumerable<CreatureSubType>> GetAll()
        {
            return await GetAllWhere(x => true);
        }

        public async Task<IEnumerable<CreatureSubType>> GetAllWhere(Expression<Func<CreatureSubType, bool>> predicate)
        {
            using var context = _contextFactory.CreateDbContext();

            IEnumerable<CreatureSubType> entities = await GetDefaultIncludes(context)
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        public async Task<CreatureSubType> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var creatureSubType = await GetDefaultIncludes(context)
                .FirstOrDefaultAsync(x => x.Id == id);

            return creatureSubType;
        }

        public async Task<CreatureSubType> Create(CreatureSubType entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<CreatureSubType> Update(int id, CreatureSubType entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public IIncludableQueryable<CreatureSubType, object> GetDefaultIncludes(ApocryphaDbContext context)
        {
            return context.CreatureSubTypes.AsNoTracking()
                .Include(x => x.CreatureSubTypeTranslations);
        }
    }
}