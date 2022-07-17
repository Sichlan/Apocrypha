using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Spells;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services
{
    public class SpellSchoolDataService : IDataService<SpellSchool>, IDefaultIncludes<SpellSchool>
    {
        private readonly ApocryphaDbContextFactory _contextFactory;
        private readonly NonQueryDataService<SpellSchool> _nonQueryDataService;

        public SpellSchoolDataService(ApocryphaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<SpellSchool>(_contextFactory);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<SpellSchool>> GetAll()
        {
            return await GetAllWhere(x => true);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<SpellSchool>> GetAllWhere(Expression<Func<SpellSchool, bool>> predicate)
        {
            using var context = _contextFactory.CreateDbContext();

            IEnumerable<SpellSchool> entities = await GetDefaultIncludes(context)
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        /// <inheritdoc />
        public async Task<SpellSchool> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            SpellSchool spellSchool = await GetDefaultIncludes(context)
                .FirstOrDefaultAsync(x => x.Id == id);

            return spellSchool;
        }

        /// <inheritdoc />
        public async Task<SpellSchool> Create(SpellSchool entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        /// <inheritdoc />
        public async Task<SpellSchool> Update(int id, SpellSchool entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        /// <inheritdoc />
        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        /// <inheritdoc />
        public IIncludableQueryable<SpellSchool, object> GetDefaultIncludes(ApocryphaDbContext context)
        {
            return context.SpellSchools.AsNoTracking()
                .Include(x => x.SpellSchoolTranslations);
        }
    }
}