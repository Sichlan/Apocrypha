using System;
using System.Globalization;
using System.Windows.Data;

namespace Apocrypha.ModernUi.Helpers.Converters;

public class IsParameterEqualConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((value == null && parameter == null) || value?.Equals(parameter) == true)
            return true;

        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}