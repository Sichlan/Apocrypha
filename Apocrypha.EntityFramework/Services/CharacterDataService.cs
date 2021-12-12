using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework.Services
{
    public class CharacterDataService : IDataService<Character>
    {
        private readonly ApocryphaDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Character> _nonQueryDataService;

        public CharacterDataService(ApocryphaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Character>(contextFactory);
        }

        public async Task<IEnumerable<Character>> GetAll()
        {
            return await GetAllWhere(x => true);
        }

        public async Task<IEnumerable<Character>> GetAllWhere(Expression<Func<Character, bool>> predicate)
        {
            using var context = _contextFactory.CreateDbContext();

            IEnumerable<Character> entities = await context.Characters
                .Include(nameof(CharacterItem))
                .Include(nameof(Item))
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        public async Task<Character> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var character = await context.Characters
                .Include(nameof(CharacterItem))
                .Include(nameof(Item))
                .FirstOrDefaultAsync(x => x.Id == id);

            return character;
        }

        public async Task<Character> Create(Character entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<Character> Update(int id, Character entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
    }
}