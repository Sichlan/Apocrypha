using System.Globalization;
using System.Windows.Data;
using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.WPF.Converters;

public class DatabaseObjectHasSpecificIdToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DatabaseObject obj && (parameter is int id || int.TryParse(parameter.ToString(), out id)))
        {
            return obj.Id == id;
        }

        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}