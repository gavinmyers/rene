using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneConsumer.Model;
using ReneConsumer.Event;
using System.Windows;

namespace ReneConsumer.CustomControl
{
    public class DataList : Rene.CustomControl.DataList
    {

        public ReneConsumer.Model.DirectorModel M
        {
            get
            {
                return ModelLocator.Locate(this);
            }
        }

        public ReneConsumer.Event.DirectorEvent E
        {
            get
            {
                return EventLocator.Locate(this);
            }
        }
        public ReneConsumer.View.WindowView V
        {
            get
            {
                return Window.GetWindow(this) as ReneConsumer.View.WindowView;
            }
        }
    }
}
