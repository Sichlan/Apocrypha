namespace Apocrypha.CommonObject.Models.Common.Translation
{
    public interface ITranslatable<T> where T : Translation<T>, new()
    {
        public string FallbackName { get; set; }
        public string FallbackDescription { get; set; }
        public TranslationCollection<T> Translations { get; set; }
    }
}