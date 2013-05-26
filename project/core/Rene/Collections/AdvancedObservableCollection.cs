using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Rene.CustomControl;
using System.Windows.Controls;
using System.ComponentModel;

namespace Rene.Collections
{
    public class AdvancedObservableCollection<T> : ObservableCollection<T>
    {
        static AdvancedObservableCollection() {

            _RefreshCommand = new RoutedCommand("RefreshCommand", typeof(AdvancedObservableCollection<T>));
            CommandManager.RegisterClassCommandBinding(typeof(AdvancedObservableCollection<T>), new CommandBinding(_RefreshCommand, OnRefreshCommand));

        }


        #region Refresh
        public event System.Collections.Specialized.NotifyCollectionChangedEventHandler Refresh;
        public virtual void DoRefresh()
        {
            if (this.Refresh != null)
            {
                this.Refresh.Invoke(this, null);
            }
        }

        private static RoutedCommand _RefreshCommand;
        public static RoutedCommand RefreshCommand
        {
            get { return _RefreshCommand; }

        }
        private static void OnRefreshCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AdvancedObservableCollection<T> mw = sender as AdvancedObservableCollection<T>;
            mw.DoRefresh();
        }
        #endregion
    }
}
