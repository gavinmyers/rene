using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ReneData.Communicator;
using System.IO;
using ReneData.DataObject;
using ReneData.Data;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading;
using System.ServiceModel.Channels;

namespace ReneServer
{

    [ServiceBehavior(
       ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerCall)]
    public class ReneCommunicatorService : IReneCommunicatorService
    {
        public static List<ReneServiceCallbackUserPair> ReneServiceCallbackUserPairs = new List<ReneServiceCallbackUserPair>();

        public ReneCommunicatorService()
        {
        }

        /* ******************** */
        /* ******************** */
        /* Generic */
        /* ******************** */
        /* ******************** */
        #region Generic
        /* TestCallBack */
        /* ******************** */
        #region TestCallBack
        bool TestCallBack(ReneServiceCallback callback)
        {
            try
            {
                CommunicationState state = ((IChannel)callback).State;
                if (state == CommunicationState.Closed || state == CommunicationState.Faulted)
                {
                    foreach (ReneServiceCallbackUserPair rs in ReneCommunicatorService.ReneServiceCallbackUserPairs)
                    {
                        if (rs.ReneServiceCallback == callback)
                        {
                            UserDisconnect(rs.User);
                            ReneCommunicatorService.ReneServiceCallbackUserPairs.Remove(rs);
                            return false;
                        }
                    }

                }
                else if (state == CommunicationState.Opened)
                {
                    //Is it REALLY opened?
                    Guid g = callback.User().PublicKey;
                }


            }
            catch (Exception e)
            {
                foreach (ReneServiceCallbackUserPair rs in ReneCommunicatorService.ReneServiceCallbackUserPairs)
                {
                    if (rs.ReneServiceCallback == callback)
                    {
                        UserDisconnect(rs.User);
                        ReneCommunicatorService.ReneServiceCallbackUserPairs.Remove(rs);
                        return false;
                    }
                }
                return false;
            }

            return true;
        }
        #endregion

        /* UserConnect */
        /* ******************** */
        #region UserConnect
        public void UserConnect()
        {
            ReneServiceCallback guest = OperationContext.Current.GetCallbackChannel<ReneServiceCallback>();
            User user = guest.User();

            ReneServiceCallbackUserPair rscu = new ReneServiceCallbackUserPair();
            rscu.ReneServiceCallback = guest;
            rscu.User = user;
            ReneServiceCallbackUserPairs.Add(rscu);


            if (!ReneCommunicatorService.ReneServiceCallbackUserPairs.Contains(rscu))
            {
                ReneCommunicatorService.ReneServiceCallbackUserPairs.Add(rscu);
            }

            ReneCommunicatorService.ReneServiceCallbackUserPairs.ForEach(
                delegate(ReneServiceCallbackUserPair rs)
                {
                    ReneServiceCallback callback = rs.ReneServiceCallback;
                    object[] o = new object[2];
                    o[0] = callback;
                    o[1] = guest;
                    Thread _backgroundThread;
                    _backgroundThread = new Thread(Thread_UserConnect);
                    _backgroundThread.SetApartmentState(ApartmentState.MTA);
                    _backgroundThread.Start(o);
                }
                );

            ReneCommunicatorService.ReneServiceCallbackUserPairs.ForEach(
                delegate(ReneServiceCallbackUserPair rs)
                {
                    ReneServiceCallback callback = rs.ReneServiceCallback;
                    object[] o = new object[2];
                    o[0] = guest;
                    o[1] = callback;
                    Thread _backgroundThread;
                    _backgroundThread = new Thread(Thread_UserConnect);
                    _backgroundThread.SetApartmentState(ApartmentState.MTA);
                    _backgroundThread.Start(o);
                }
                );

        }

        void Thread_UserConnect(object s)
        {

            object[] senders = s as object[];

            ReneServiceCallback sender = senders[0] as ReneServiceCallback;
            ReneServiceCallback receiver = senders[1] as ReneServiceCallback;

            if (!TestCallBack(sender) || !TestCallBack(receiver))
            {
                return;
            }

            receiver.Broadcast("UserConnect", sender.User(), "");

        }
        #endregion

        /* UserDisconnect */
        /* ******************** */
        #region UserDisconnect
        public void UserDisconnect()
        {
            ReneServiceCallback guest = OperationContext.Current.GetCallbackChannel<ReneServiceCallback>();
            User user = guest.User();
            UserDisconnect(user);
        }

        public void UserDisconnect(User u)
        {
            ReneCommunicatorService.ReneServiceCallbackUserPairs.ForEach(
                delegate(ReneServiceCallbackUserPair rs)
                {
                    ReneServiceCallback callback = rs.ReneServiceCallback;
                    object[] o = new object[2];
                    o[0] = callback;
                    o[1] = u;
                    Thread _backgroundThread;
                    _backgroundThread = new Thread(Thread_UserDisconnect);
                    _backgroundThread.SetApartmentState(ApartmentState.MTA);
                    _backgroundThread.Start(o);
                }
                );
        }

        void Thread_UserDisconnect(object s)
        {

            object[] senders = s as object[];

            ReneServiceCallback receiver = senders[0] as ReneServiceCallback;
            User user = senders[1] as User;

            if (!TestCallBack(receiver))
            {
                return;
            }
            Console.WriteLine("UserDisconnect");
            receiver.Broadcast("UserDisconnect", user, "");
        }
        #endregion

        /* ApplicationInformation */
        /* ******************** */
        #region ApplicationInformation
        public string ApplicationInformation()
        {
            ReneServiceCallback guest = OperationContext.Current.GetCallbackChannel<ReneServiceCallback>();
            TextReader r = new StreamReader("ApplicationInformation.xml");
            return r.ReadToEnd();
        }
        #endregion

        /* Upload */
        /* ******************** */
        #region Upload
        public void Upload(ReneCommunicatorFile request)
        {
            ReneServiceCallback guest = OperationContext.Current.GetCallbackChannel<ReneServiceCallback>();
            string fileName = request.FileName;

            string uploadPath = request.FileDestination;
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

        /* Download */
        /* ******************** */
        #region Download
        public ReneCommunicatorFile Download(ReneCommunicatorFileRequest request)
        {
            ReneServiceCallback guest = OperationContext.Current.GetCallbackChannel<ReneServiceCallback>();
            ReneCommunicatorFile up = new ReneCommunicatorFile();
            FileStream file = new FileStream("ApplicationInformation.xml", FileMode.Open, FileAccess.Read);
            up.Data = file;
            up.FileName = "ApplicationInformation3.xml";
            up.FileDestination = "";
            return up;
        }
        #endregion

        /* ForceDownload */
        /* ******************** */
        #region ForceDownload
        /*
         * Force Download
        ReneCommunicatorFile up = new ReneCommunicatorFile();
        FileStream file = new FileStream("ApplicationInformation.xml", FileMode.Open, FileAccess.Read);
        up.Data = file;
        up.FileName = "ApplicationInformation2.xml";
        up.FileDestination = "";
        guest.Download(up);
        file.Close();
        */
        #endregion

        #endregion

        /* ******************** */
        /* ******************** */
        /* Game Engine Calls */
        /* ******************** */
        /* ******************** */
        #region Game Engine

        /* TankMove */
        /* ******************** */
        #region TankMove
        public bool TankMove(double x, double y)
        {
            ReneServiceCallback guest = OperationContext.Current.GetCallbackChannel<ReneServiceCallback>();
            User user = guest.User();

            ReneCommunicatorService.ReneServiceCallbackUserPairs.ForEach(
                delegate(ReneServiceCallbackUserPair rs)
                {
                    ReneServiceCallback callback = rs.ReneServiceCallback;

                    object[] o = new object[4];
                    o[0] = guest;
                    o[1] = callback;
                    o[2] = x;
                    o[3] = y;

                    Thread _backgroundThread;
                    _backgroundThread = new Thread(TankMove_DoWork);
                    _backgroundThread.SetApartmentState(ApartmentState.MTA);
                    _backgroundThread.Start(o);

                }
                );



            guest.TankMove("TankMoveDone", user, x, y);

            return true;
        }
        
        void TankMove_DoWork(object s)
        {
            Guid g = Guid.NewGuid();

            object[] o = s as object[];

            ReneServiceCallback sender = o[0] as ReneServiceCallback;
            ReneServiceCallback receiver = o[1] as ReneServiceCallback;
            double x = (double)o[2];
            double y = (double)o[3];

            if (!TestCallBack(sender) || !TestCallBack(receiver))
            {
                return;
            }

            if (sender.User().PublicKey != receiver.User().PublicKey)
            {
                receiver.TankMove("TankMoveDone", sender.User(), x, y);
            }

        }
        #endregion

        #endregion

        /* ******************** */
        /* ******************** */
        /* Database Calls */
        /* ******************** */
        /* ******************** */
        #region Database Calls

        /* spUsers */
        /* ******************** */
        #region spUsers
        public List<User> spUsers(User u)
        {
            return DatabaseReceiver.spUsers(u);
        }
        #endregion

        #endregion
    }

    public class ReneServiceCallbackUserPair
    {
        public ReneServiceCallback ReneServiceCallback;
        public User User;
    }
}
