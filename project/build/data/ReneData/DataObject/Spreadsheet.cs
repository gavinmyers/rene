using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Markup;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Data;

namespace ReneData.DataObject
{
    public class Spreadsheet : Rene.DataObject.DataObject
    {
        public Spreadsheet()
        {
        }

        private Uri _uri;
        public Uri uri
        {
            get { return _uri; }
            set { _uri = value; OnPropertyChanged("uri"); }
        }
    }
}