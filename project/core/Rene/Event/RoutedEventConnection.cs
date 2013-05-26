using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Rene.Event
{
    public class RoutedEventConnection
    {

        public RoutedEventConnection(RoutedEvent re, RoutedEventHandler o)
        {
            this.RoutedEvent = re;
            this.RoutedEventHandler = o;
        }

        private RoutedEvent _RoutedEvent;
        public RoutedEvent RoutedEvent
        {
            get
            {
                return _RoutedEvent;
            }
            set { _RoutedEvent = value; }
        }

        private RoutedEventHandler _RoutedEventHandler;
        public RoutedEventHandler RoutedEventHandler
        {
            get
            {
                return _RoutedEventHandler;
            }
            set { _RoutedEventHandler = value; }
        }
    }
}
