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
    public class CreatureTypeDataService : IDataService<CreatureType>, IDefaultIncludes<CreatureType>
    {
        private readonly ApocryphaDbContextFactory _contextFactory;
        private readonly NonQueryDataService<CreatureType> _nonQueryDataService;

        public CreatureTypeDataService(ApocryphaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<CreatureType>(contextFactory);
        }

        public async Task<IEnumerable<CreatureType>> GetAll()
        {
            return await GetAllWhere(x => true);
        }

        public async Task<IEnumerable<CreatureType>> GetAllWhere(Expression<Func<CreatureType, bool>> predicate)
        {
            using var context = _contextFactory.CreateDbContext();

            IEnumerable<CreatureType> entities = await GetDefaultIncludes(context)
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        public async Task<CreatureType> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var creatureType = await GetDefaultIncludes(context)
                .FirstOrDefaultAsync(x => x.Id == id);

            return creatureType;
        }

        public async Task<CreatureType> Create(CreatureType entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<CreatureType> Update(int id, CreatureType entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public IIncludableQueryable<CreatureType, object> GetDefaultIncludes(ApocryphaDbContext context)
        {
            return context.CreatureTypes.AsNoTracking()
                .Include(x => x.CreatureTypeTranslations);
        }
    }
}