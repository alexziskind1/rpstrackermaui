using Telerik.Maui.Controls.Compatibility.Chart;

namespace RPS.UI.Formatters
{
    public class DateLabelFormatter : LabelFormatterBase<DateTime>
    {
        public override string FormatTypedValue(DateTime value)
        {
            return value.ToString("MMM");

            //if (value.Day == 1)
            //{
            //    return value.Day + "st";
            //}
            //else if (value.Day == 2)
            //{
            //    return value.Day + "nd";
            //}
            //else if (value.Day == 3)
            //{
            //    return value.Day + "rd";
            //}
            //else
            //{
            //    return value.Day + "th";
            //}
        }
    }
}
