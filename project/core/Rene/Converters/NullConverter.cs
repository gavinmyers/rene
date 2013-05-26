using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Rene.Converters
{
    public class NullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object
            parameter, System.Globalization.CultureInfo culture)
        {
            string p = parameter.ToString();
            if (p.Equals("NULL"))
            {
                if (value is DateTime)
                {
                    DateTime dt = (DateTime)value ;
                    return dt == DateTime.MinValue;
                }
                return value == null;
            }
            else
            {
                if (value is DateTime)
                {
                    
                    DateTime dt = (DateTime)value ;
                    return dt != DateTime.MinValue;
                }
                return value != null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
