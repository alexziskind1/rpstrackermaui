

using RPS.Core.Models;
using System.Globalization;

namespace RPS.UI.Converters
{
    public class FullNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PtUser user = (PtUser)value;
            return user.FullName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string avatar = (string)value;
            return null;
        }

    }
}
