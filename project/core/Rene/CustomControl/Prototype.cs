using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Rene.CustomControl
{
    public class Prototype : GroupBox
    {
        #region Text1
        public string Text1
        {
            get { return (string)GetValue(Text1Property); }
            set { SetValue(Text1Property, value); }
        }

        public static readonly DependencyProperty Text1Property =
          DependencyProperty.Register("Text1", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text2
        public string Text2
        {
            get { return (string)GetValue(Text2Property); }
            set { SetValue(Text2Property, value); }
        }

        public static readonly DependencyProperty Text2Property =
          DependencyProperty.Register("Text2", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text3
        public string Text3
        {
            get { return (string)GetValue(Text3Property); }
            set { SetValue(Text3Property, value); }
        }

        public static readonly DependencyProperty Text3Property =
          DependencyProperty.Register("Text3", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text4
        public string Text4
        {
            get { return (string)GetValue(Text4Property); }
            set { SetValue(Text4Property, value); }
        }

        public static readonly DependencyProperty Text4Property =
          DependencyProperty.Register("Text4", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text5
        public string Text5
        {
            get { return (string)GetValue(Text5Property); }
            set { SetValue(Text5Property, value); }
        }

        public static readonly DependencyProperty Text5Property =
          DependencyProperty.Register("Text5", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text6
        public string Text6
        {
            get { return (string)GetValue(Text6Property); }
            set { SetValue(Text6Property, value); }
        }

        public static readonly DependencyProperty Text6Property =
          DependencyProperty.Register("Text6", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text7
        public string Text7
        {
            get { return (string)GetValue(Text7Property); }
            set { SetValue(Text7Property, value); }
        }

        public static readonly DependencyProperty Text7Property =
          DependencyProperty.Register("Text7", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text8
        public string Text8
        {
            get { return (string)GetValue(Text8Property); }
            set { SetValue(Text8Property, value); }
        }

        public static readonly DependencyProperty Text8Property =
          DependencyProperty.Register("Text8", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text9
        public string Text9
        {
            get { return (string)GetValue(Text9Property); }
            set { SetValue(Text9Property, value); }
        }

        public static readonly DependencyProperty Text9Property =
          DependencyProperty.Register("Text9", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Text10
        public string Text10
        {
            get { return (string)GetValue(Text10Property); }
            set { SetValue(Text10Property, value); }
        }

        public static readonly DependencyProperty Text10Property =
          DependencyProperty.Register("Text10", typeof(string),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion


        #region Content1
        public object Content1
        {
            get { return (object)GetValue(Content1Property); }
            set { SetValue(Content1Property, value); }
        }

        public static readonly DependencyProperty Content1Property =
          DependencyProperty.Register("Content1", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content2
        public object Content2
        {
            get { return (object)GetValue(Content2Property); }
            set { SetValue(Content2Property, value); }
        }

        public static readonly DependencyProperty Content2Property =
          DependencyProperty.Register("Content2", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content3
        public object Content3
        {
            get { return (object)GetValue(Content3Property); }
            set { SetValue(Content3Property, value); }
        }

        public static readonly DependencyProperty Content3Property =
          DependencyProperty.Register("Content3", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content4
        public object Content4
        {
            get { return (object)GetValue(Content4Property); }
            set { SetValue(Content4Property, value); }
        }

        public static readonly DependencyProperty Content4Property =
          DependencyProperty.Register("Content4", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content5
        public object Content5
        {
            get { return (object)GetValue(Content5Property); }
            set { SetValue(Content5Property, value); }
        }

        public static readonly DependencyProperty Content5Property =
          DependencyProperty.Register("Content5", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content6
        public object Content6
        {
            get { return (object)GetValue(Content6Property); }
            set { SetValue(Content6Property, value); }
        }

        public static readonly DependencyProperty Content6Property =
          DependencyProperty.Register("Content6", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content7
        public object Content7
        {
            get { return (object)GetValue(Content7Property); }
            set { SetValue(Content7Property, value); }
        }

        public static readonly DependencyProperty Content7Property =
          DependencyProperty.Register("Content7", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content8
        public object Content8
        {
            get { return (object)GetValue(Content8Property); }
            set { SetValue(Content8Property, value); }
        }

        public static readonly DependencyProperty Content8Property =
          DependencyProperty.Register("Content8", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content9
        public object Content9
        {
            get { return (object)GetValue(Content9Property); }
            set { SetValue(Content9Property, value); }
        }

        public static readonly DependencyProperty Content9Property =
          DependencyProperty.Register("Content9", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion

        #region Content10
        public object Content10
        {
            get { return (object)GetValue(Content10Property); }
            set { SetValue(Content10Property, value); }
        }

        public static readonly DependencyProperty Content10Property =
          DependencyProperty.Register("Content10", typeof(object),
          typeof(Prototype), new UIPropertyMetadata());
        #endregion
    }
}
