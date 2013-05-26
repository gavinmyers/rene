using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Rene.Converters
{
    public sealed class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ListViewItem)
            {

                ListViewItem item = (ListViewItem)value;
                ListView listView =
                    ItemsControl.ItemsControlFromItemContainer(item) as ListView;
                // Get the index of a ListViewItem
                int index =
                    listView.ItemContainerGenerator.IndexFromContainer(item);

                if (index % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            throw new NotSupportedException();

        }

    }
}
