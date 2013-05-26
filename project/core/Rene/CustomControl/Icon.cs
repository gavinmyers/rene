using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rene.CustomControl
{
    /// <summary>
    /// This is an empty class used to create
    /// an Icon. This class is empty because there are
    /// no values defined for icons.
    /// 
    /// <example>
    /// This will create the calendar icon
    /// <code>
    /// <cc:Icon Style="{DynamicResource Calendar}"/>
    /// </code>          
    /// </example>
    /// </summary>
    public class Icon : Button
    {
        static Icon()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Icon), new FrameworkPropertyMetadata(typeof(Icon)));
        }

    }
}
