using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using Rene.Util;
using System.Runtime.Serialization;

namespace Rene.DataObject
{
    [Serializable]
    [DataContract]
    public class DataObject :  INotifyPropertyChanged, ICloneable
    {

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

        [DataMember]
        private bool _HasChanged = false;
        public bool HasChanged
        {
            get { return _HasChanged; }
            set { _HasChanged = value; OnPropertyChanged("HasChanged"); }
        }


        [DataMember]
        private double _SortOrder = 0;
        public double SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; OnPropertyChanged("SortOrder"); }
        }

        [DataMember]
        private bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { _IsSelected = value; OnPropertyChanged("IsSelected"); }
        }

        [DataMember]
        private bool _IsVisible = true;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; OnPropertyChanged("IsVisible"); }
        }

        [DataMember]
        private bool _IsEditable = false;
        public bool IsEditable
        {
            get { return _IsEditable; }
            set { _IsEditable = value; OnPropertyChanged("IsEditable"); }
        }

        [DataMember]
        private bool _IsRemoveable = false;
        public bool IsRemoveable
        {
            get { return _IsRemoveable; }
            set { _IsRemoveable = value; OnPropertyChanged("IsRemoveable"); }
        }

        #region ICloneable Members

        public object Clone()
        {

            return MemberwiseClone();

        }

        #endregion

    }
}
