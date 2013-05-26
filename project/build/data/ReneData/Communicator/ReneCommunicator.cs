using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Specialized;
using System.Windows;
using ReneData.DataObject;
using System.IO;

namespace ReneData.Communicator
{
    /// <summary>
    /// SERVER to CLIENT communication
    /// </summary>

    #region ReneCommunicator
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
    #endregion

    [CallbackBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        UseSynchronizationContext = false)]
    public class ReneCommunicatorBridge : ReneServiceCallback
    {
        #region ctor
        public ReneCommunicatorBridge()
        {
            ReneCommunicatorServiceClient = new ReneCommunicatorServiceClient(new InstanceContext(this), "BasicHttpBinding_IReneCommunicatorService");
            ReneCommunicatorServiceClient.Open();
        }
        #endregion

        public static User _User;
        public ReneCommunicatorServiceClient ReneCommunicatorServiceClient;
        public event BroadcastReceivedHandler BroadcastReceived;
        public delegate void BroadcastReceivedHandler(ReneCommunicatorBroadcast rcb, EventArgs e);

        /* ******************** */
        /* ******************** */
        /* Generic Calls */
        /* ******************** */
        /* ******************** */
        #region Generic
        User ReneServiceCallback.User()
        {
            User u = new User();
            u.PublicKey = ReneCommunicatorBridge._User.PublicKey;
            u.FirstName = ReneCommunicatorBridge._User.FirstName;
            return u;
        }


        public void Broadcast(string evt, User sender, object data)
        {
            Console.WriteLine(data);
            ReneCommunicatorBroadcast rcb = new ReneCommunicatorBroadcast();
            rcb.Event = evt;
            rcb.Data = data;
            rcb.sender = sender;

            if (BroadcastReceived != null)
            {
                BroadcastReceived(rcb, null);
            }
            //this.BroadcastEvent.Invoke(rcb, null);
        }

        public void Download(ReneCommunicatorFile request)
        {
            string fileName = request.FileName;
            string uploadPath = request.FileDestination;
            if (uploadPath.Equals(""))
            {
                uploadPath = System.Environment.CurrentDirectory;
            }
            string filePath = Path.Combine(Path.GetFullPath(uploadPath), fileName);

            FileStream fs = null;
            try
            {
                fs = File.Create(filePath);
                byte[] buffer = new byte[1024];
                int read = 0;
                while ((read = request.Data.Read(buffer, 0, buffer.Length)) != 0)
                {
                    fs.Write(buffer, 0, read);
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }

                if (request.Data != null)
                {
                    request.Data.Close();
                    request.Data.Dispose();
                }
            }
        }
        #endregion


        /* ******************** */
        /* ******************** */
        /* Game Engine Calls */
        /* ******************** */
        /* ******************** */
        #region Custom
        public void TankMove(string evt, User sender, double x, double y)
        {
            ReneCommunicatorBroadcast rcb = new ReneCommunicatorBroadcast();
            rcb.Event = evt;
            rcb.Data = new Vector(x, y);
            rcb.sender = sender;

            if (BroadcastReceived != null)
            {
                BroadcastReceived(rcb, null);
            }
            //this.BroadcastEvent.Invoke(rcb, null);
        }
        #endregion

    }

    #region ReneCommunicatorBroadcast
    public class ReneCommunicatorBroadcast
    {
        public string Event;
        public object Data;
        public User sender;
    }
    #endregion
}
