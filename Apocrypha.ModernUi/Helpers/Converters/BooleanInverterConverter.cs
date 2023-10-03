using System;
using System.Globalization;
using System.Windows.Data;

namespace Apocrypha.ModernUi.Helpers.Converters;

public class BooleanInverterConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool a)
            return !a;

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool a)
            return !a;

        return value;
    }
}