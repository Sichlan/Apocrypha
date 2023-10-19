using System.ComponentModel.DataAnnotations.Schema;
using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models;

/// <summary>
/// Displays the option to take a feat and criteria for feats selectable with this option.<br/>
/// <inheritdoc cref="IFeatOption"/>
/// </summary>
public class RaceFeatOption : DatabaseObject, IFeatOption
{
    public Race Race { get; set; }

    /// <inheritdoc/>
    public string IdList { get; set; }

    [NotMapped]
    public ICollection<int> FeatIds
    {
        get
        {
            return (IdList + "").Split(";")
                .Where(x => int.TryParse(x, out var _))
                .Select(x => int.Parse(x))
                .ToList();
        }
        set => IdList = string.Join(';', value);
    }
}