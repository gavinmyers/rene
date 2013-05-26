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
using System.Xml;
using System.IO;
using System.Net;
using System.Diagnostics;
using ReneData.Communicator;

namespace ReneClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
            this.AllowsTransparency = true;
            this.Background = null;
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
            this.ShowInTaskbar = false;
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            ReneCommunicatorServiceClient rcsc = ReneCommunicator.GetServiceClient();

            XmlDocument serverXML = new XmlDocument();
            serverXML.LoadXml(rcsc.ApplicationInformation());
            string serverVersion = serverXML.SelectSingleNode("/ApplicationInformation/Client").Attributes["Version"].InnerText;
            string serverDownload = serverXML.SelectSingleNode("/ApplicationInformation/Client").Attributes["Download"].InnerText;

            FileStream fs = new FileStream("ApplicationInformation.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlDocument clientXML = new XmlDocument();
            clientXML.Load(fs);
            string clientVersion = clientXML.SelectSingleNode("/ApplicationInformation/Client").Attributes["Version"].InnerText;

            if (!serverVersion.Equals(clientVersion))
            {
                WebClient Client = new WebClient();
                Client.DownloadFile(serverDownload, "Update.exe");
                Process p = new Process();
                p.StartInfo.FileName = @"Update.exe";
                p.Start();
                while (p.HasExited == false)
                {
                }
            }

            System.Diagnostics.Process.Start(@"ReneView\ReneView.exe");

            FileStream newfs = new FileStream("ApplicationInformation.xml", FileMode.Truncate,
                                              FileAccess.Write,
                                              FileShare.ReadWrite);
            serverXML.Save(newfs);

            App.Current.Shutdown();
        }

    }
}
