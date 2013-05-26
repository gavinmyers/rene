using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using ReneConsumer.View;

namespace ReneConsumer.Model
{
    public class ModelLocator
    {
        public static ReneConsumer.Model.DirectorModel Locate(Control c)
        {
            return LocateDeep(c);
        }

        private static ReneConsumer.Model.DirectorModel LocateDeep(object c)
        {
            FrameworkElement fw = c as FrameworkElement;
            if (fw.TemplatedParent is ControlView)
            {
                return (fw.TemplatedParent as ControlView).M;
            }
            else if (fw.TemplatedParent is FrameworkElement)
            {
                return LocateDeep(fw.TemplatedParent);
            }
            else
            {
                return (Window.GetWindow((c as DependencyObject)) as ReneConsumer.View.WindowView).General.DirectorModel as ReneConsumer.Model.DirectorModel;
            }

        }
    }
}
