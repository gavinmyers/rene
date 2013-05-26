using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using ReneData.DataObject;
using ReneData.Data;
using System.Collections;
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

namespace ReneServer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
 
        public Window1()
        {
            ServiceHost ReneCommunicatorHost = null;

            ReneCommunicatorHost = new ServiceHost(typeof(ReneCommunicatorService));
            ReneCommunicatorHost.Open();
            foreach (ServiceEndpoint endpoint in ReneCommunicatorHost.Description.Endpoints)
            {
                Console.WriteLine("File Transfer service listening on {0}", endpoint.Address.ToString());
            }



        }
    }

}
