using System.Linq.Expressions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services;

public class RuleBookDataService : IDataService<RuleBook>, IDefaultIncludes<RuleBook>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<RuleBook> _nonQueryDataService;

    public RuleBookDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<RuleBook>(contextFactory);
    }

    public async Task<IEnumerable<RuleBook>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<RuleBook>> GetAllWhere(Expression<Func<RuleBook, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        IEnumerable<RuleBook> entities = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return entities;
    }

    public async Task<RuleBook> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var ruleBook = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return ruleBook;
    }

    public async Task<RuleBook> Create(RuleBook entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<RuleBook> Update(int id, RuleBook entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<RuleBook, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.RuleBooks.AsNoTracking()
            .Include(x => x.RuleBookTranslations)
            .Include(x => x.Edition);
    }
}