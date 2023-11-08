using System;
using System.Windows.Markup;

namespace Apocrypha.ModernUi.Helpers;

public class GenericObjectFactoryExtension : MarkupExtension
{
    public Type Type { get; set; }
    public Type T { get; set; }

    /// <inheritdoc />
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var genericType = Type.MakeGenericType(T);

        return Activator.CreateInstance(genericType);
    }
}