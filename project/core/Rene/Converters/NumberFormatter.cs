using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Rene.Converters
{
	public class NumberFormatter : IValueConverter
	{
		public object Convert(object value, Type targetType, object
			parameter, System.Globalization.CultureInfo culture)
		{
			try
			{
				return System.Convert.ToDouble(value).ToString(parameter as string);
			}
			catch (Exception ex)
			{
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
