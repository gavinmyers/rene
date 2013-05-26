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
    /// A generic container used to create
    /// Objects that contain only one other object
    /// 
    /// <example>
    /// This will create a container around a set of buttons with
    /// a shadow
    /// <code>
    /// <cc:Container Style="{DynamicResource Shadow}">
    ///     <cc:Container.Content>
    ///         <StackPanel>
    ///             <Button Content="Button 1"/>
    ///             <Button Content="Button 2"/>
    ///             <Button Content="Button 3"/>
    ///             <Button Content="Button 4"/>
    ///         </StackPanel>
    ///     </cc:Container.Content>
    /// </cc:Container>
    /// </code>          
    /// </example>
    /// </summary>
    public class Container : GroupBox
    {
        static Container()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Container), new FrameworkPropertyMetadata(typeof(Container)));

        }


    }
}
