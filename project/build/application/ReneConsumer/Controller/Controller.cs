using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneConsumer.Model;
using System.Windows;
using ReneData.Data;
using System.Collections;
using ReneData.DataObject;
using System.ServiceModel;
using System.IO;
using ReneData.Communicator;
using ReneGameLogic.Sprite;

namespace ReneConsumer.Controller
{
    public class Controller : AppJumper.Controller.Controller
    {
        public override void Instance()
        {
            /* ******************** */
            /* Generic Calls */
            /* ******************** */
            E.Listen("UploadFiles", UploadFiles);
            E.Listen("UserConnect", UserConnect);
            E.Listen("UserDisconnect", UserDisconnect);

            /* ******************** */
            /* Database Calls */
            /* ******************** */
            E.Listen("SearchUser", SearchUser);
            E.Listen("DeleteUser", DeleteUser);

            /* ******************** */
            /* Game Engine Calls */
            /* ******************** */
            E.Listen("TankUp", TankUp);
            E.Listen("TankDown", TankDown);
            E.Listen("TankLeft", TankLeft);
            E.Listen("TankRight", TankRight);

            /* ******************** */
            /* Connection */
            /* ******************** */
            M.Session.User = new User();
            M.Session.User.PublicKey = Guid.NewGuid();
            M.Session.User.PrivateKey = Guid.NewGuid();
            ReneCommunicatorBridge._User = M.Session.User;
            S.UserConnect();
        }
        
        /* ******************** */
        /* ******************** */
        /* Generic Calls */
        /* ******************** */
        /* ******************** */
        #region Generic

        // ReneCommunicatorFile request = S.Download(new ReneCommunicatorFileRequest());

        void UserConnect(object sender, RoutedEventArgs e)
        {
            ReneCommunicatorBroadcast rcb = e.OriginalSource as ReneCommunicatorBroadcast;

            foreach (User u in M.Session.Users)
            {
                if (u.PublicKey == rcb.sender.PublicKey)
                {
                    return;
                }
            }
            M.Session.Users.Add(rcb.sender);
        }

        void UserDisconnect(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("DISCONNECT!!!");
            ReneCommunicatorBroadcast rcb = e.OriginalSource as ReneCommunicatorBroadcast;
            foreach (User u in M.Session.Users)
            {
                if (u.PublicKey == rcb.sender.PublicKey)
                {
                    M.Session.Users.Remove(u);
                    return;
                }
            }
        }

        void UploadFiles(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            foreach (FileStream fs in M.AddEdit.Uploads)
            {
                S.Upload("test.jpg", fs);
                fs.Close();
            }

            E.RaiseEvent("UploadFilesDone");
        }
        #endregion

        /* ******************** */
        /* ******************** */
        /* Database Calls */
        /* ******************** */
        /* ******************** */
        #region Database
        void SearchUser(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            
            /* Too bypass the creation of a server simply call
             * the DatabaseReceiver directly
             * DatabaseReceiver.spUsers(M.Search.User);
             */


            List<User> al = S.spUsers(M.Search.User);
            M.Search.Users.Clear();
            foreach (User u in al)
            {
                M.Search.Users.Add(u);
            }
            E.RaiseEvent("SearchUserDone");

        }


        void DeleteUser(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            /*
            if (ReneServiceClient.DeleteUser(M.AddEdit.User) && M.Search.Users.Contains(M.AddEdit.User))
            {
                M.Search.Users.Remove(M.AddEdit.User);
            }
            E.RaiseEvent("DeleteUserDone");
             */
        }
        #endregion

        /* ******************** */
        /* ******************** */
        /* Game Engine Calls */
        /* ******************** */
        /* ******************** */
        #region Game
        void TankUp(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            InteractiveElement ie = M.Session.User.Tank.InteractiveElement;
            double x = 0;
            double y = 0;
            if (ie != null)
            {
                x = x + ie.GetPosition().X;
                y = y + ie.GetPosition().Y;

            }

            S.TankMove(x, y - 5);
        }

        void TankDown(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            InteractiveElement ie = M.Session.User.Tank.InteractiveElement;
            double x = 0;
            double y = 0;
            if (ie != null)
            {
                x = x + ie.GetPosition().X;
                y = y + ie.GetPosition().Y;
            }
            S.TankMove(x, y + 5);
        }

        void TankLeft(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            InteractiveElement ie = M.Session.User.Tank.InteractiveElement;
            double x = 0;
            double y = 0;
            if (ie != null)
            {
                x = x + ie.GetPosition().X;
                y = y + ie.GetPosition().Y;
            }
            S.TankMove(x - 5, y);
        }

        void TankRight(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            InteractiveElement ie = M.Session.User.Tank.InteractiveElement;
            double x = 0;
            double y = 0;
            if (ie != null)
            {
                x = x + ie.GetPosition().X;
                y = y + ie.GetPosition().Y;
            }

            S.TankMove(x + 5, y);
        }
        #endregion

    }
}
