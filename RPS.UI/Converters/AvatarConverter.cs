
using RPS.Core.Models;
using System.Globalization;


namespace RPS.UI.Converters;

public class AvatarConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        PtUser user = (PtUser)value;
        string avatar = user.Avatar;
        string textToTrim = "images/";

        if (avatar.StartsWith(textToTrim))
            avatar = avatar.Remove(0, textToTrim.Length);

        return avatar;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string avatar = (string)value;
        return null;
    }
}
