using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Specialized;
using System.Windows;

namespace ReneData.Communicator
{
    public class ReneCommunicator
    {


        public static ReneCommunicatorServiceClient GetServiceClient()
        {
            return ReneCommunicator.ReneCommunicatorBridge.ReneCommunicatorServiceClient;
        }

        /**********************
            ReneCommunicatorBridge
        ***********************/
        private static ReneCommunicatorBridge _ReneCommunicatorBridge;
        public static ReneCommunicatorBridge ReneCommunicatorBridge
        {
            get
            {

                if (ReneCommunicator._ReneCommunicatorBridge == null)
                {
                    ReneCommunicator._ReneCommunicatorBridge = new ReneCommunicatorBridge();
                }
                return ReneCommunicator._ReneCommunicatorBridge;
            }
            set { ReneCommunicator._ReneCommunicatorBridge = value; }
        }
    }

    [CallbackBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        UseSynchronizationContext = false)]
    public class ReneCommunicatorBridge : ReneServiceCallback
    {

        public ReneCommunicatorServiceClient ReneCommunicatorServiceClient;
        public ReneCommunicatorBridge()
        {
            ReneCommunicatorServiceClient = new ReneCommunicatorServiceClient(new InstanceContext(this), "BasicHttpBinding_IReneCommunicatorService");
            ReneCommunicatorServiceClient.Open();
        }


        public void Broadcast(string evt, object data)
        {
            Console.WriteLine(data);
            ReneCommunicatorBroadcast rcb = new ReneCommunicatorBroadcast();
            rcb.Event = evt;
            rcb.Data = data;

            if (BroadcastReceived != null)
            {
                BroadcastReceived(rcb, null);
            }
        }


        public event BroadcastReceivedHandler BroadcastReceived;
        public delegate void BroadcastReceivedHandler(ReneCommunicatorBroadcast rcb, EventArgs e);


    }

    public class ReneCommunicatorBroadcast
    {
        public string Event;
        public object Data;
    }
}
