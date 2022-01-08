using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class AllignmentTranslation : Translation<AllignmentTranslation>
    {
        public Allignment Allignment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}