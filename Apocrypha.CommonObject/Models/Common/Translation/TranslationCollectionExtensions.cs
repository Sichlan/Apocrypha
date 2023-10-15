namespace Apocrypha.CommonObject.Models.Common.Translation;

public static class TranslationCollectionExtensions
{
    public static TranslationCollection<T> ToTranslationCollection<T>(this ICollection<T> collection) where T : Translation<T>, new()
    {
        var output = new TranslationCollection<T>();

        foreach (var translation in collection)
        {
            output.Add(translation);
        }

        return output;
    }
}