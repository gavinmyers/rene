using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace ReneGameLogic.Sprite
{

    public class InteractiveElement : Canvas
    {


        public void IncrementPosition(double x, double y)
        {
            Vector v2 = this.GetPosition();
            double StartX = v2.X;
            double StartY = v2.Y;

            double EndX = StartX + x;
            double EndY = StartY + y;

            if (StartX > EndX)
            {
                this.Margin = new Thickness(this.Margin.Left - (StartX - EndX), this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
            }
            else if (StartX < EndX)
            {
                this.Margin = new Thickness(this.Margin.Left + (EndX - StartX), this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
            }

            if (StartY > EndY)
            {
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top - (EndY - StartY), this.Margin.Right, this.Margin.Bottom);
            }
            else if (StartY < EndY)
            {
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top + (StartY - EndY), this.Margin.Right, this.Margin.Bottom);
            }
        }

        public void SetPosition(Vector v)
        {
            Vector v2 = this.GetPosition();
            double StartX = v2.X;
            double StartY = v2.Y;
            double EndX = v.X;
            double EndY = v.Y;

            Console.WriteLine(this.Margin.Bottom + " vs " + EndY);
            this.Margin = new Thickness(EndX, EndY, this.Margin.Right, this.Margin.Bottom);

            /*
            if (StartX > EndX)
            {
                this.Margin = new Thickness(this.Margin.Left - (EndX - StartX), this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
            }
            else if (StartX < EndX)
            {
                this.Margin = new Thickness(this.Margin.Left + (StartX - EndX), this.Margin.Top, this.Margin.Right, this.Margin.Bottom);   
            }

            if (StartY > EndY)
            {
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top - (EndY - StartY), this.Margin.Right, this.Margin.Bottom);
            }
            else if (StartY < EndY)
            {
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top + (StartY - EndY), this.Margin.Right, this.Margin.Bottom);
            }
             */
        }

        /*
        public void SetPosition(Vector v)
        {
            this.Margin = new Thickness(v.X, this.Margin.Top, this.Margin.Right, v.Y);

        }
        */

        public Vector GetPosition()
        {
            return VisualTreeHelper.GetOffset(this);
        }

        public bool HitTest(InteractiveElement ie)
        {
            return false;
        }
    }
}
