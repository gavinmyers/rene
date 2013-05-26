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
    /// The AdvancedTextBox is a modification of the normal text box
    /// with the addition of controls/abilities/flags that are not 
    /// present in the normal TextBox
    /// 
    /// Additional Functions
    /// IsAdvancedFocus
    /// This allows the TextBox to be a "Select All" textbox where
    /// whenever the user clicks on a value it highlights the entire
    /// value. This is useful for numeric entries
    /// 
    /// IsNumeric
    /// Forces values entered to be values 0-9. Also
    /// adds additional functionality (up/down arrows increase
    /// or decrease the value)
    /// 
    /// MinimumValue
    /// The minimum value for a numeric textbox
    /// 
    /// MaximumValue
    /// The maximum value for a numeric textbox
    /// 
    /// IsBlur
    /// A blur text is the text behind the value. The most common
    /// example of this is a search bar. "Enter search criteria"
    /// will be the text on the text box until the user clicks,
    /// then that text goes away
    /// 
    /// BlurText
    /// The text accompanying the IsBlur property
    /// 
    /// 
    /// <example>
    /// <code>
    /// <cc:AdvancedTextBox x:Name="year"  
    ///                 BlurText="yyyy" 
    ///                 MaximumValue="2025" 
    ///                 MinimumValue="2006"  
    ///                 IsNumeric="true" 
    ///                 IsAdvancedFocus="true" 
    ///                 MaxLength="4" />
    /// </code>          
    /// </example>
    /// 
    /// </summary>
    public class AdvancedTextBox : TextBox
    {
        public AdvancedTextBox()
        {
            this.PreviewMouseDown += new MouseButtonEventHandler(AdvancedTextBox_PreviewMouseDown);
            this.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(AdvancedTextBox_GotKeyboardFocus);
            this.PreviewTextInput += new TextCompositionEventHandler(AdvancedTextBox_PreviewTextInput);
            this.PreviewKeyUp += new KeyEventHandler(AdvancedTextBox_PreviewKeyUp);
            this.LostFocus += new RoutedEventHandler(AdvancedTextBox_LostFocus);
            this.GotFocus += new RoutedEventHandler(AdvancedTextBox_GotFocus);
            this.TextChanged += new TextChangedEventHandler(AdvancedTextBox_TextChanged);
            this.Loaded += new RoutedEventHandler(AdvancedTextBox_Loaded);
        }


        /// <summary>
        /// XAML Dependency Properties
        /// IsAdvancedFocus
        /// IsNumeric
        /// MinimumValue
        /// MaximumValue
        /// IsBlur
        /// BlurText
        /// </summary>

        #region IsAdvancedFocus
        public bool IsAdvancedFocus
        {
            get { return (bool)GetValue(IsAdvancedFocusProperty); }
            set {  SetValue(IsAdvancedFocusProperty, value); }
        }

        public static readonly DependencyProperty IsAdvancedFocusProperty =
          DependencyProperty.Register("IsAdvancedFocus", typeof(bool),
          typeof(AdvancedTextBox), new UIPropertyMetadata());

        #endregion

        #region Numeric

        #region IsNumeric

        public bool IsNumeric
        {
            get { return (bool)GetValue(IsNumericProperty); }
            set { SetValue(IsNumericProperty, value); }
        }

        public static readonly DependencyProperty IsNumericProperty =
          DependencyProperty.Register("IsNumeric", typeof(bool),
          typeof(AdvancedTextBox), new UIPropertyMetadata());

        #endregion
        #region MinimumValue

        public int MinimumValue
        {
            get { return (int)GetValue(MinimumValueProperty); }
            set { SetValue(MinimumValueProperty, value); }
        }

        public static readonly DependencyProperty MinimumValueProperty =
          DependencyProperty.Register("MinimumValue", typeof(int),
          typeof(AdvancedTextBox), new UIPropertyMetadata());

        #endregion

        #region MaximumValue
        public int MaximumValue
        {
            get { return (int)GetValue(MaximumValueProperty); }
            set { SetValue(MaximumValueProperty, value); }
        }

        public static readonly DependencyProperty MaximumValueProperty =
          DependencyProperty.Register("MaximumValue", typeof(int),
          typeof(AdvancedTextBox), new UIPropertyMetadata());
        #endregion

        #endregion

        #region Blur

        #region IsBlur

        public bool IsBlur
        {
            get { return (bool)GetValue(IsBlurProperty); }
            set { SetValue(IsBlurProperty, value); }
        }
        public static readonly DependencyProperty IsBlurProperty =
          DependencyProperty.Register("IsBlur", typeof(bool),
          typeof(AdvancedTextBox), new UIPropertyMetadata());

        #endregion

        #region BlurText
        public string BlurText
        {
            get { return GetValue(BlurTextProperty).ToString(); }
            set { SetValue(BlurTextProperty, value); }
        }

        public static readonly DependencyProperty BlurTextProperty =
          DependencyProperty.Register("BlurText", typeof(string),
          typeof(AdvancedTextBox), new UIPropertyMetadata("",OnBlurTextInvalidated));
        #endregion

        #endregion


        /// <summary>
        /// Used whenever the text box is clicked on to determine if the blur text should go away
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnBlurTextInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("OnBlurTextInvalidated");
            AdvancedTextBox atb = (AdvancedTextBox)d;
            atb.IsBlur = true;
        }

        /// <summary>
        /// Event when a key has been pressed.
        /// Used by the Numeric function to increase/decrease the value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AdvancedTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("AdvancedTextBox_PreviewKeyUp");
            AdvancedTextBox ftb = sender as AdvancedTextBox;
            if (ftb.IsNumeric)
            {
                if (e.Key == Key.Up)
                {

                    int i = 0;
                    if (!ftb.Text.Equals(""))
                    {
                        i = int.Parse(ftb.Text);
                    }
                    i++;
                    if (i <= ftb.MaximumValue)
                    {
                        ftb.Text = i.ToString();
                    }
                    if (i < ftb.MinimumValue)
                    {
                        ftb.Text = ftb.MinimumValue.ToString();
                    }
                }

                if (e.Key == Key.Down)
                {
                    int i = 0;
                    if (!ftb.Text.Equals(""))
                    {
                        i = int.Parse(ftb.Text);
                    }
                    i--;
                    if (i >= ftb.MinimumValue)
                    {
                        ftb.Text = i.ToString();
                    }
                    else
                    {
                        ftb.Text = ftb.MinimumValue.ToString();
                    }

                    if (i > ftb.MaximumValue)
                    {
                        ftb.Text = ftb.MaximumValue.ToString();
                    }
                    
                }


            }
        }

        /// <summary>
        /// Event when text has been added
        /// Used by the Numeric check to see if the text is a valid number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AdvancedTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Console.WriteLine("AdvancedTextBox_PreviewTextInput");
            AdvancedTextBox ftb = sender as AdvancedTextBox;
            if (ftb.IsNumeric)
            {
                foreach (Char c in e.Text.ToCharArray())
                {
                    if (Char.IsNumber(c) || Char.IsControl(c)) continue;
                    else e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Event when the mouse has clicked
        /// Used by the blur text remove any blur effects
        /// Used by the advanced focus to select all text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AdvancedTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("AdvancedTextBox_PreviewMouseDown");
            AdvancedTextBox ftb = sender as AdvancedTextBox;
            ftb.IsBlur = false;

            if (ftb.IsAdvancedFocus)
            {
                ftb.Focus();
                string t = ftb.Text;
                ftb.Text = t;
                ftb.SelectAll();
                ftb.Focus();
                e.Handled = true;
            }

        }

        /// <summary>
        /// Event Keyboard is focused on text box
        /// Used by blur to remove blur text
        /// Used by Focus to select all text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AdvancedTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Console.WriteLine("AdvancedTextBox_GotKeyboardFocus");
            AdvancedTextBox ftb = sender as AdvancedTextBox;
            ftb.IsBlur = false;
            if (ftb.IsAdvancedFocus)
            {
                ftb.Focus();
                string t = ftb.Text;
                ftb.Text = t;
                ftb.SelectAll();
                ftb.Focus();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Event focus has been lost on the text box
        /// Used by the blur to place blur text back on (if the text box is empty)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AdvancedTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            AdvancedTextBox ftb = sender as AdvancedTextBox;
            if (!ftb.BlurText.Equals("") && ftb.Text.Equals(""))
            {
                Console.WriteLine("BLARG");
                ftb.IsBlur = true;
            }
        }

        /// <summary>
        /// Event focus is on the text box
        /// Used by the blur to hide the blur text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AdvancedTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            AdvancedTextBox ftb = sender as AdvancedTextBox;
            ftb.IsBlur = false;
        }


        void AdvancedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AdvancedTextBox ftb = sender as AdvancedTextBox;
            Console.WriteLine("AdvancedTextBox_TextChanged " + (ftb.Text.Length == 0));
            ftb.IsBlur = ftb.Text.Equals("");

        }


        void AdvancedTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            AdvancedTextBox ftb = sender as AdvancedTextBox;
            Console.WriteLine("AdvancedTextBox_Loaded " + (ftb.Text.Length == 0));
            ftb.IsBlur = ftb.Text.Equals("");
        }
    }
}
