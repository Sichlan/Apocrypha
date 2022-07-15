using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services
{
    public class RaceDataService : IDataService<Race>, IDefaultIncludes<Race>
    {
        private readonly ApocryphaDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Race> _nonQueryDataService;

        public RaceDataService(ApocryphaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Race>(contextFactory);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Race>> GetAll()
        {
            return await GetAllWhere(x => true);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Race>> GetAllWhere(Expression<Func<Race, bool>> predicate)
        {
            using var context = _contextFactory.CreateDbContext();

            IEnumerable<Race> entities = await GetDefaultIncludes(context)
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        /// <inheritdoc />
        public async Task<Race> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var race = await GetDefaultIncludes(context)
                .FirstOrDefaultAsync(x => x.Id == id);

            return race;
        }

        /// <inheritdoc />
        public async Task<Race> Create(Race entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        /// <inheritdoc />
        public async Task<Race> Update(int id, Race entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        /// <inheritdoc />
        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        /// <inheritdoc />
        public IIncludableQueryable<Race, object> GetDefaultIncludes(ApocryphaDbContext context)
        {
            return context.Races.Include(x => x.RuleBook)
                .ThenInclude(x => x.RuleBookTranslations)
                
                .Include(x => x.Type)
                .ThenInclude(x => x.CreatureTypeTranslations)

                .Include(x => x.SubType)
                .ThenInclude(x => x.CreatureSubTypeTranslations)

                .Include(x => x.Size)
                .ThenInclude(x => x.CreatureSizeCategoryTranslations)

                .Include(x => x.RaceMovementModes)
                .ThenInclude(x => x.MovementMode)
                .ThenInclude(x => x.MovementModeTranslations)
                .Include(x => x.RaceMovementModes)
                .ThenInclude(x => x.MovementManeuverability)
                .ThenInclude(x => x.MovementManeuverabilityTranslations)

                .Include(x => x.RaceSenses)
                .ThenInclude(x => x.Sense)
                .ThenInclude(x => x.SenseTranslations)

                .Include(x => x.AutomaticLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.Alphabet)
                .ThenInclude(x => x.AlphabetTranslations)
                .Include(x => x.AutomaticLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.LanguageTranslations)

                .Include(x => x.BonusLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.Alphabet)
                .ThenInclude(x => x.AlphabetTranslations)
                .Include(x => x.BonusLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.LanguageTranslations)

                .Include(x => x.AdditionalFeatOptions)

                .Include(x => x.SpecialAbilities)
                .ThenInclude(x => x.RaceSpecialAbilityTranslations)
                
                .Include(x => x.RaceTranslations);
        }
    }
}