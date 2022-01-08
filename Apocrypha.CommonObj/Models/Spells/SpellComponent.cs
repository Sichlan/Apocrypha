using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models.Spells
{
    /// <summary>
    /// Describes a single spell component.
    /// Notation is as follows:
    /// - Verbal / Somatic: only SpellComponentType is filled
    /// - Material / Arcane Focus / Divine Focus: linked to an item, optionally with a MinimalItemGoldValue and/or Count + CountIndicator
    /// - XP: a Count is given
    /// - Other: OtherComponentText lists the needed component, OtherComponentName lists a name for the component category (like "corruption" or "abstinence")
    /// </summary>
    public class SpellComponent : DatabaseObject
    {
        public SpellComponentType SpellComponentType { get; set; }
        public Item? Item { get; set; }
        public decimal? MinimalItemGoldValue { get; set; }
        public int? Count { get; set; }
        public string? CountIndicator { get; set; }
        public string? OtherComponentText { get; set; }
        public string? OtherComponentName { get; set; }
    }
}