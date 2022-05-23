using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Spells;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework.Services
{
    public class SpellSchoolDataService : IDataService<SpellSchool>
    {
        private readonly ApocryphaDbContextFactory _contextFactory;
        private readonly NonQueryDataService<SpellSchool> _nonQueryDataService;

        public SpellSchoolDataService(ApocryphaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<SpellSchool>(_contextFactory);
        }

        public async Task<IEnumerable<SpellSchool>> GetAll()
        {
            return await GetAllWhere(x => true);
        }

        public async Task<IEnumerable<SpellSchool>> GetAllWhere(Expression<Func<SpellSchool, bool>> predicate)
        {
            using var context = _contextFactory.CreateDbContext();

            IEnumerable<SpellSchool> entities = await context.SpellSchools
                .Include(x => x.SpellSchoolTranslations)
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        public async Task<SpellSchool> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            SpellSchool spellSchool = await context.SpellSchools
                .Include(x => x.SpellSchoolTranslations)
                .FirstOrDefaultAsync(x => x.Id == id);

            return spellSchool;
        }

        public async Task<SpellSchool> Create(SpellSchool entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<SpellSchool> Update(int id, SpellSchool entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
    }
}