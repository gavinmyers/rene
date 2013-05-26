using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Rene.CustomControl
{
    public class JumpMenu : ComboBox
    {
        public JumpMenu()
        {
            //this.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(JumpMenu_PreviewMouseUp);
        }

        void JumpMenu_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Change keyboard focus.
            if (e.OriginalSource is Button)
            {
                //MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }

        }


        #region Header
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
          DependencyProperty.Register("Header", typeof(string),
          typeof(JumpMenu), new UIPropertyMetadata());
        #endregion

    }
}
