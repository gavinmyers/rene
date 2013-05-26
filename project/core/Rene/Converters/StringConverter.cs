using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Rene.Converters
{
    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object
            parameter, System.Globalization.CultureInfo culture)
        {
            if (int.Parse(parameter.ToString()) > 0)
            {
                string f = value.ToString();
                int i = int.Parse(parameter.ToString());
                if (f.Length > i)
                {
                    return f.Remove(i+3) + "...";
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
