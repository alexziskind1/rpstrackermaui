using RPS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.UI.Converters
{
    public class PriorityColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PriorityEnum status = (PriorityEnum)value;

            switch (status)
            {
                case PriorityEnum.High:
                    return Color.FromHex("b27100");
                case PriorityEnum.Medium:
                    return Color.FromHex("0c6d00");
                case PriorityEnum.Low:
                    return Color.FromHex("002b6d");
                case PriorityEnum.Critical:
                    return Color.FromHex("820101");
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
