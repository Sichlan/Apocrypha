using Apocrypha.CommonObject.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework.ExtensionMethods;

public static class DbContextExtensionMethods
{
    public static void DetachLocal<T>(this DbContext context, T t, int id)
        where T : DatabaseObject
    {
        var local = context.Set<T>()
            .FirstOrDefault(x => x.Id == id);

        if (local != null)
        {
            context.Entry(local).State = EntityState.Detached;
        }

        // context.Set<T>().Attach(t);
        context.Entry(t).State = EntityState.Modified;
    }
}