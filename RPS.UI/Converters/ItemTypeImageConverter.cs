using RPS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.UI.Converters
{
    public class ItemTypeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ItemTypeEnum itemType = (ItemTypeEnum)value;

            switch (itemType)
            {
                case ItemTypeEnum.PBI:
                    return "icon_pbi.png";
                case ItemTypeEnum.Bug:
                    return "icon_bug.png";
                case ItemTypeEnum.Chore:
                    return "icon_chore.png";
                case ItemTypeEnum.Block:
                    return "icon_block.png";
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
