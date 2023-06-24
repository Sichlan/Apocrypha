using System;
using System.Globalization;
using System.Windows.Data;
using ModernWpf;

namespace Apocrypha.ModernUi.Helpers.Converters
{
    public class InverseAppThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ApplicationTheme)value switch
            {
                ApplicationTheme.Light => ElementTheme.Dark,
                ApplicationTheme.Dark => ElementTheme.Light,
                _ => throw new ArgumentOutOfRangeException(nameof(value))
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}