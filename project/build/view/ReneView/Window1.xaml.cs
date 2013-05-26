using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReneConsumer.Model;
using ReneConsumer.View;
using ReneData.Communicator;

namespace ReneView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ReneConsumer.View.WindowView
    {
        public Window1()
        {
            InitializeComponent();
            this.Background = null;
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
            this.ShowInTaskbar = false;
            this.WindowStyle = WindowStyle.None;
            this.AllowsTransparency = true;
        }


        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            ReneCommunicator.ReneCommunicatorBridge.BroadcastReceived += new ReneCommunicatorBridge.BroadcastReceivedHandler(ReneCommunicatorBridge_BroadcastReceived);

            DashboardWindowView wv = new DashboardWindowView();
            wv.ShowDetached();
            wv.Close += new RoutedEventHandler(wv_Close);

        }

        void ReneCommunicatorBridge_BroadcastReceived(ReneCommunicatorBroadcast rcb, EventArgs e)
        {
            
        }

        void wv_Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }


    }
}
