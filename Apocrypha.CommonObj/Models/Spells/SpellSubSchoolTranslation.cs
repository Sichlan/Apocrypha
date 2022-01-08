using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellSubSchoolTranslation : Translation<SpellSubSchoolTranslation>
    {
        public SpellSubSchool SpellSubSchool { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}