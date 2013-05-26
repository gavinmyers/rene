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
    public class OuterGlow : GroupBox
    {
        public OuterGlow()
        {
            this.Loaded += new RoutedEventHandler(OuterGlow_Loaded);
        }

        void OuterGlow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Build();
        }

        #region GlowColor
        public Brush GlowColor
        {
            get { return (Brush)GetValue(GlowColorProperty); }
            set { SetValue(GlowColorProperty, value); }
        }
        public static readonly DependencyProperty GlowColorProperty =
          DependencyProperty.Register("GlowColor", typeof(Brush),
          typeof(OuterGlow), new UIPropertyMetadata(Brushes.Black, OnGlowColorInvalidated));

        private static void OnGlowColorInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("OnGlowColorInvalidated");
            OuterGlow og = (OuterGlow)d;
            og.Build();
        }

        #endregion

        #region GlowSize
        public int GlowSize
        {
            get { return (int)GetValue(GlowSizeProperty); }
            set { SetValue(GlowSizeProperty, value); }
        }
        public static readonly DependencyProperty GlowSizeProperty =
          DependencyProperty.Register("GlowSize", typeof(int),
          typeof(OuterGlow), new UIPropertyMetadata(5, OnGlowSizeInvalidated));

        private static void OnGlowSizeInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("OnGlowSizeInvalidated");
            OuterGlow og = (OuterGlow)d;
            og.Build();
        }

        #endregion

        #region CornerRadius
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
          DependencyProperty.Register("CornerRadius", typeof(int),
          typeof(OuterGlow), new UIPropertyMetadata(0, OnCornerRadiusInvalidated));

        private static void OnCornerRadiusInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("OnCornerRadiusInvalidated");
            OuterGlow og = (OuterGlow)d;
            og.Build();
        }
        
        private Border CurrentBorder = new Border();
        private object ContentInset = new object();

        public void Build()
        {
            if (!this.IsLoaded)
            {
                return;
            }

            if (this.Content is Border)
            {
                Border b = this.Content as Border;
                if (b.Name.Equals("PART_OuterGlowBorder"))
                {
                    return;
                }
                
            }
            Border currentBorder = this.CurrentBorder;
            this.CurrentBorder.Name = "PART_OuterGlowBorder";
            this.CurrentBorder.Margin = new Thickness(this.GlowSize * -1);
            int radius = this.CornerRadius;
            int size = this.GlowSize;
            double opacity = 0.01;
            for (int i = 0; i < size; i++)
            {
                Brush brush = this.GlowColor.Clone();
                brush.Opacity = opacity ;
                Border b = new Border();
                b.Background = brush;
                b.Margin = new Thickness(1);
                b.CornerRadius = new CornerRadius(radius);
                currentBorder.Child = b;
                currentBorder = b;
                opacity += 0.05;

                if(i == (size - 1)) {
                    if (this.Content != this.CurrentBorder)
                    {
                        Border b3 = new Border();
                        b3.Background = brush;
                        b3.CornerRadius = new CornerRadius(radius);
                        currentBorder.Child = b3;
                        currentBorder = b3;
                        opacity += 0.05;

                        this.ContentInset = this.Content;
                        this.Content = this.CurrentBorder;
                        b3.Child = this.ContentInset as UIElement;
                    }
                }
            }

        }

        #endregion

    }
}
