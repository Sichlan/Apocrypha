using System.Linq.Expressions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services;

public class AllignmentDataService : IDataService<Allignment>, IDefaultIncludes<Allignment>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<Allignment> _nonQueryDataService;

    public AllignmentDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<Allignment>(contextFactory);
    }

    public async Task<IEnumerable<Allignment>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<Allignment>> GetAllWhere(Expression<Func<Allignment, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        var allignments = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return allignments;
    }

    public async Task<Allignment> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var allignment = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return allignment;
    }

    public async Task<Allignment> Create(Allignment entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<Allignment> Update(int id, Allignment entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<Allignment, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.Allignments
            .Include(x => x.AllignmentTranslations);
    }
}