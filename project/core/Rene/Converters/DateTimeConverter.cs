using System;
using System.Windows.Data;
namespace Rene.Converters
{
    [ValueConversion(typeof(object), typeof(string))]
    public class DateTimeFormatter : IValueConverter
    {

        #region IValueConverter Members
/// <summary>
/// Used to convert a string
/// <example>
/// In this example there is a DateTime property on the object
/// and that date time object is being formatted 
/// to Long Month - Long Year (March 2008)
/// <code>
/// 
///		<Label 
///			Content="{Binding Path=DateTime, 
///			Converter={StaticResource dateformat},
///			ConverterParameter='\{0:MMMM yyyy\}',
///			UpdateSourceTrigger=PropertyChanged,
///			RelativeSource={RelativeSource TemplatedParent}}" />
/// 
/// </code>          
/// </example>
/// </summary>
/// <param name="value"></param>
/// <param name="targetType"></param>
/// <param name="parameter"></param>
/// <param name="culture"></param>
/// <returns></returns>
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            string formatString = parameter as string;
            try
            {
                if (formatString != null)
                {
                    return string.Format(culture, formatString, value);
                }
                else
                {
                    return value.ToString();
                }
            }
            catch { }
            return "Error";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            // we don't intend this to ever be called
            return null;
        }

        #endregion
    }

}

