namespace Apocrypha.CommonObject.Models.Common.Translation
{
    /// <summary>
    /// Represents a translation entry for localizing database contents.
    /// <a href="https://stackoverflow.com/questions/25302393/best-practices-to-localize-entities-with-ef-code-first">Source</a>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Translation<T> : DatabaseObject where T : Translation<T>, new()
    {
        public string CultureName { get; set; }
    }
}