using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using ReneConsumer.View;

namespace ReneConsumer.Event
{
    public class EventLocator
    {
        public static ReneConsumer.Event.DirectorEvent Locate(Control c)
        {
            return LocateDeep(c);
        }

        private static ReneConsumer.Event.DirectorEvent LocateDeep(object c)
        {
            FrameworkElement fw = c as FrameworkElement;
            if (fw.TemplatedParent is ControlView)
            {
                return (fw.TemplatedParent as ControlView).E;
            }
            else
            {
                return (Window.GetWindow((c as DependencyObject)) as ReneConsumer.View.WindowView).General.DirectorEvent as ReneConsumer.Event.DirectorEvent;
            }

            //todo fix for control templates, no worky
            if (c != null)
            {
                if (c is ReneConsumer.View.ControlView)
                {
                    Console.WriteLine("ControlView!");
                    ReneConsumer.View.ControlView cv = c as ReneConsumer.View.ControlView;
                    return cv.General.DirectorEvent as ReneConsumer.Event.DirectorEvent;
                }
                else if (c is ReneConsumer.View.WindowView)
                {
                    Console.WriteLine("WindowView!");
                    ReneConsumer.View.WindowView cv = c as ReneConsumer.View.WindowView;
                    return cv.General.DirectorEvent as ReneConsumer.Event.DirectorEvent;
                }
                else if (c is Control)
                {
                    Console.WriteLine("Control!");
                    Control cn = c as Control;
                    return LocateDeep(cn.Parent);
                }
                else if (c is FrameworkElement)
                {
                    FrameworkElement cc = c as FrameworkElement;
                    return LocateDeep(cc.Parent);
                }

            }
            return null;
        }
    }
}
