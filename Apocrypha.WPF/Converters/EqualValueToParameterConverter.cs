using System;
using System.Globalization;
using System.Windows.Data;

namespace Apocrypha.WPF.Converters
{
    public class EqualValueToParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value ?? 'a').ToString() == (parameter ?? 'b').ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Not supposed to be executed!");
        }
    }
}