using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;

namespace Apocrypha.CommonObject.Models.Common.Translation;

public class TranslationCollection<T> : Collection<T> where T : Translation<T>, new()
{
    public T this[CultureInfo cultureInfo]
    {
        get
        {
            var translation = this.FirstOrDefault(x => x.CultureName == cultureInfo.Name);

            if (translation == null)
            {
                translation = new T
                {
                    CultureName = cultureInfo.Name
                };
                Add(translation);
            }

            return translation;
        }
        set
        {
            var translation = this.FirstOrDefault(x => x.CultureName == cultureInfo.Name);

            if (translation != null)
            {
                Remove(translation);
            }

            value.CultureName = cultureInfo.Name;
            Add(value);
        }
    }

    public T this[string culture]
    {
        get
        {
            var translation = this.FirstOrDefault(x => x.CultureName == culture);

            // if (translation == null)
            // {
            //     translation = new T
            //     {
            //         CultureName = culture
            //     };
            //     Add(translation);
            // }

            return translation;
        }
        set
        {
            var translation = this.FirstOrDefault(x => x.CultureName == culture);

            if (translation != null)
            {
                Remove(translation);
            }

            value.CultureName = culture;
            Add(value);
        }
    }

    public bool HasCulture(string culture)
    {
        return this.Any(x => x.CultureName == culture);
    }

    public bool HasCulture(CultureInfo culture)
    {
        return this.Any(x => x.CultureName == culture.Name);
    }

    public TranslationCollection<T> Copy()
    {
        var output = new TranslationCollection<T>();

        foreach (var translation in this)
        {
            var propertyInfos = translation.GetType().GetProperties();
            var newTranslation = new T();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (!propertyInfo.CanWrite)
                    continue;

                propertyInfo.SetValue(newTranslation, propertyInfo.GetValue(translation));
            }

            output.Add(newTranslation);
        }

        return output;
    }
}