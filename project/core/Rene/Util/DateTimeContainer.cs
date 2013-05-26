using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Rene.Util
{
    public class DateTimeContainer : INotifyPropertyChanged
    {
        public DateTimeContainer()
        {
        }

        public DateTimeContainer(DateTime d)
        {
            this.DateTime = d;
        }

        private DateTime _DateTime = new DateTime();
        public DateTime DateTime
        {
            get { return _DateTime; }
            set
            {
                _DateTime = value;
                OnPropertyChanged("DateTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }



    }
}
