using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ReneGameLogic.Sprite;
using ReneData.Communicator;
using ReneData.DataObject;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Markup;
using System.Windows.Documents;

namespace ReneConsumer.View
{
    public class DashboardWindowView : WindowView
    {
        public DashboardWindowView()
        {
            this.Loaded += new System.Windows.RoutedEventHandler(DashboardWindowView_Loaded);
            this.KeyDown += new KeyEventHandler(DashboardWindowView_KeyDown);

            E.Listen("TankMoveDone", TankMoveDone);
        }


        void TankMoveDone(object sender, RoutedEventArgs e)
        {
            ReneCommunicatorBroadcast rcb = e.OriginalSource as ReneCommunicatorBroadcast;

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new System.Windows.Forms.MethodInvoker(delegate()
            {
                Vector v = (Vector)rcb.Data;
                foreach (User u in M.Session.Users)
                {
                    if (u.PublicKey == rcb.sender.PublicKey)
                    {

                        if (u.Tank.InteractiveElement == null)
                        {
                            InteractiveElement ie = new InteractiveElement();
                            ie.Background = Brushes.Red;
                            ie.Width = 25;
                            ie.Height = 25;
                            ie.HorizontalAlignment = HorizontalAlignment.Left;
                            ie.VerticalAlignment = VerticalAlignment.Top;
                            Grid g = this.Template.FindName("PART_Tanks", this) as Grid;
                            g.Children.Add(ie);

                            u.Tank.InteractiveElement = ie;

                        }
                        u.Tank.InteractiveElement.SetPosition(v);

                        if (u.PublicKey == M.Session.User.PublicKey)
                        {
                            M.Session.User.Tank.InteractiveElement = u.Tank.InteractiveElement;
                        }

                    }
                }

            }));
        }


        void DashboardWindowView_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                E.RaiseEvent("TankUp");
            }
            else if (e.Key == Key.Down)
            {
                E.RaiseEvent("TankDown");
            }
            else if (e.Key == Key.Left)
            {
                E.RaiseEvent("TankLeft");
            }
            else if (e.Key == Key.Right)
            {
                E.RaiseEvent("TankRight");
            }

        }

        void DashboardWindowView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            e.Handled = true;

        }
    }
}
