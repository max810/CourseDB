using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseDB
{
    public class SearchValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string cellText = values[0] == null ? string.Empty : values[0].ToString();
            string searchText = values[1] as string;

            if (!string.IsNullOrEmpty(searchText) && !string.IsNullOrEmpty(cellText))
            {
                return cellText.ToLower().Contains(searchText.ToLower());
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool x = (bool)value;
            switch (x)
            {
                case false:
                    return "-";
                default:
                    return "+";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class AnyBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Any(x => System.Convert.ToBoolean(x));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;
            return string.Format("{0:dd.MM.yyyy}", dateTime);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public static class Misc
    {
        public static int FromMask(string input, int defaultValue)
        {
            return input.Trim() == "*" || string.IsNullOrWhiteSpace(input) ? defaultValue : int.Parse(input);
        }
    }
}
