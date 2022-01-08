using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellSchoolTranslation : Translation<SpellSchoolTranslation>
    {
        public SpellSchool SpellSchool { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}