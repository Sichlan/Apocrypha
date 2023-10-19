using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Apocrypha.CommonObject.Models.Common.Translation;

/// <summary>
/// Represents a translation entry for localizing database contents.
/// <a href="https://stackoverflow.com/questions/25302393/best-practices-to-localize-entities-with-ef-code-first">Source</a>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Translation<T> : DatabaseObject where T : Translation<T>, new()
{
    private string _cultureName;

    public string CultureName
    {
        get => _cultureName;
        set => _cultureName = value;
    }

    public string Name { get; set; }
    public string Description { get; set; }

    [NotMapped]
    public CultureInfo CultureInfo
    {
        get => new(CultureName);
        set
        {
            if (value != null)
                CultureName = value.Name;
        }
    }
}