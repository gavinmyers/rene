using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using Rene.Collections;

namespace Rene.Event
{
    public class DirectorEvent : UIElement
    {

        public AdvancedObservableCollection<RoutedEvent> Events = new AdvancedObservableCollection<RoutedEvent>();
        public AdvancedObservableCollection<RoutedEventConnection> ActiveEvents = new AdvancedObservableCollection<RoutedEventConnection>();
        private string key = "";
        public DirectorEvent()
        {
            this.key = this.GetHashCode() + "";
        }

        ~DirectorEvent()
        {
            foreach (RoutedEventConnection rec2 in ActiveEvents)
            {
                this.RemoveHandler(rec2.RoutedEvent, rec2.RoutedEventHandler);
            }

        }

        public void AddActive(RoutedEventConnection rec)
        {
            RemoveActive(rec);
            ActiveEvents.Add(rec);
        }
        public void RemoveActive(RoutedEventConnection rec)
        {
            foreach (RoutedEventConnection rec2 in ActiveEvents)
            {
                if (rec2.RoutedEvent == rec.RoutedEvent && rec.RoutedEventHandler.Target == rec2.RoutedEventHandler.Target)
                {
                    this.RemoveHandler(rec2.RoutedEvent, rec2.RoutedEventHandler);
                    ActiveEvents.Remove(rec2);
                    return;
                }
            }
        }


        public bool RaiseEvent(string name)
        {
            RoutedEvent re = Get(name);

            if (re != null)
            {
                RaiseEvent(new RoutedEventArgs(re, ""));
                return true;
            }
            return false;
        }

        public bool RaiseEvent(string name, object o)
        {
            RoutedEvent re = Get(name);
            if (re != null)
            {

                RaiseEvent(new RoutedEventArgs(re, o));
                return true;
            }
            return false;
        }

        public bool Listen(string name, RoutedEventHandler o)
        {

            RoutedEvent re = Get(name);
            if (re == null)
            {
                Events.Add(EventManager.RegisterRoutedEvent(key + name, RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DirectorEvent)));
                re = Get(name);
            }
            AddActive(new RoutedEventConnection(re, o));
            AddHandler(
            re
            , o);
            return true;
            

        }


        public bool Ignore(string name, RoutedEventHandler o)
        {
            RoutedEvent re = Get(name);
            if (name != null)
            {
                RemoveActive(new RoutedEventConnection(re, o));
                RemoveHandler(
                re
                , o);
                return true;
            }
            return false;
        }



        public RoutedEvent Get(string name)
        {
            foreach (RoutedEvent re in Events)
            {
                if (re.Name == key+name)
                {
                    return re;
                }
            }
            return null;
        }

    }
}
